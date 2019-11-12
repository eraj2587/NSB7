using System;
using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;
using WUBS.Cct.Treasury.DomainModel.Enums;

namespace WUBS.Cct.Treasury.DomainModel.Financial
{
    [Serializable]
    public struct Rate : IComparable
    {
        [JsonProperty]
        private readonly decimal unmultipliedUnroundedRateValue;
        [JsonProperty]
        public Currency UnitCurrency; //base,transaction
        [JsonProperty]
        public Currency RefCurrency; //quote,price,
        public RateMetaData MetaData;
        public readonly RateConvention RateConvention; //EUR->GBP->AUD->NZD->USD->...

        public decimal RoundedValue
        {
            get { return Math.Round(unmultipliedUnroundedRateValue, NumberOfDecimalsUnmultiplied, MidpointRounding.AwayFromZero); }
        }

        public decimal MultipliedValue
        {
            get { return Math.Round(unmultipliedUnroundedRateValue * Multiplier, NumberOfDecimalsMultiplied, MidpointRounding.AwayFromZero); }
        }

        public int Multiplier
        {
            get { return RateConvention == RateConvention.Direct ? MetaData.MultiplierDirect : MetaData.MultiplierIndirect; }
        }

        public int NumberOfDecimalsMultiplied
        {
            get { return IsDirect() ? MetaData.NumberOfDecimalsDirectMultiplied : MetaData.NumberOfDecimalsIndirectMultiplied; }
        }

        public int NumberOfDecimalsUnmultiplied
        {
            get { return IsDirect() ? MetaData.NumberOfDecimalsDirectUnmultiplied : MetaData.NumberOfDecimalsIndirectUnmultiplied; }
        }

        public static readonly Rate NullRate = new Rate(Currency.Null, Currency.Null, 0, 1, 1, 4, 4, RateConvention.Direct);

        public Rate(Currency unitCurrency,
            Currency refCurrency,
            decimal unmultipliedUnroundedRateValue,
            int multiplierDirect,
            int multiplierIndirect,
            int numDecimalsDirectMultiplied,
            int numDecimalsIndirectMultiplied,
            RateConvention rateConvention)
        {
            Debug.Assert(rateConvention != RateConvention.Default, "Ambigious rate convention, should be set to direct or indirect");

            UnitCurrency = unitCurrency;
            RefCurrency = refCurrency;
            this.unmultipliedUnroundedRateValue = unmultipliedUnroundedRateValue;
            MetaData = new RateMetaData(numDecimalsDirectMultiplied, numDecimalsIndirectMultiplied, multiplierDirect, multiplierIndirect);
            RateConvention = rateConvention;
        }

        [JsonConstructor]
        public Rate(Currency unitCurrency,
            Currency refCurrency,
            decimal unmultipliedUnroundedRateValue,
            RateMetaData metaData,
            RateConvention rateConvention)
        {
            UnitCurrency = unitCurrency;
            RefCurrency = refCurrency;
            MetaData = metaData;
            this.unmultipliedUnroundedRateValue = unmultipliedUnroundedRateValue;
            RateConvention = rateConvention;
        }

        public static Rate CreateRate(Currency unitCurrency,
            Currency refCurrency,
            decimal rateValue,
            bool rateValueIsMultiplied,
            RateMetaData metaData,
            RateConvention rateConvention)
        {
            var rateValueUnmultiplied = rateValue;
            var rateMultiplier = rateConvention == RateConvention.Direct
                ? metaData.MultiplierDirect
                : metaData.MultiplierIndirect;
            if (rateValueIsMultiplied)
                rateValueUnmultiplied = rateValue / rateMultiplier;

            if (rateConvention == RateConvention.Indirect)
                return new Rate(refCurrency, unitCurrency, rateValueUnmultiplied, metaData, rateConvention);
            return new Rate(unitCurrency, refCurrency, rateValueUnmultiplied, metaData, rateConvention);
        }

        public Money Convert(Money money)
        {
            if (this == NullRate)
                throw new InvalidOperationException("Cannot convert NullRate.");

            if (money.Currency.Equals(UnitCurrency))
            {
                return new Money(RefCurrency, money.Amount * unmultipliedUnroundedRateValue);
            }

            if (money.Currency.Equals(RefCurrency))
            {
                if (unmultipliedUnroundedRateValue == 0)
                    return new Money(UnitCurrency, 0m);

                return new Money(UnitCurrency, money.Amount / unmultipliedUnroundedRateValue);
            }

            throw new InvalidOperationException("Error attempting to apply rate to incorrect currency.");
        }

        public Rate Inverted()
        {
            decimal inverseValue = 0;
            if (unmultipliedUnroundedRateValue != 0)
                inverseValue = 1m / unmultipliedUnroundedRateValue;

            var inverseRateConvention = RateConvention.Direct;
            if (RateConvention == RateConvention.Direct)
            {
                inverseRateConvention = RateConvention.Indirect;
            }

            return new Rate(RefCurrency, UnitCurrency, inverseValue, MetaData, inverseRateConvention);
        }

        public Rate NewValue(decimal newValue)
        {
            return new Rate(UnitCurrency, RefCurrency, newValue, MetaData, RateConvention);
        }

        public Rate Round()
        {
            return new Rate(UnitCurrency, RefCurrency, RoundedValue, MetaData, RateConvention);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Rate))
            {
                return false;
            }
            var another = (Rate)obj;
            return HasSameCurrencyPairAs(another) && unmultipliedUnroundedRateValue == another.unmultipliedUnroundedRateValue;
        }

        public static bool operator ==(Rate one, Rate another)
        {
            return one.Equals(another);
        }

        public static bool operator !=(Rate rate1, Rate rate2)
        {
            return !(rate1 == rate2);
        }

        public static bool operator <=(Rate rate1, Rate rate2)
        {
            if (!rate1.HasSameCurrencyPairAs(rate2))
                throw new ArgumentException("Currency pair of the two rates are not the same.");

            return rate1.unmultipliedUnroundedRateValue <= rate2.unmultipliedUnroundedRateValue;
        }

        public static bool operator >=(Rate rate1, Rate rate2)
        {
            if (!rate1.HasSameCurrencyPairAs(rate2))
                throw new ArgumentException("Currency pair of the two rates are not the same.");

            return rate1.unmultipliedUnroundedRateValue >= rate2.unmultipliedUnroundedRateValue;
        }

        public bool IsDirect()
        {
            return RateConvention == RateConvention.Direct;
        }

        public static bool operator >(Rate rate1, Rate rate2)
        {
            return !(rate1 <= rate2);
        }

        public static bool operator <(Rate rate1, Rate rate2)
        {
            return !(rate1 >= rate2);
        }

        public static Rate operator +(Rate rate, decimal markup)
        {
            return rate.NewValue(rate.unmultipliedUnroundedRateValue + markup);
        }

        public override int GetHashCode()
        {
            return UnitCurrency.GetHashCode() ^ RefCurrency.GetHashCode() ^ unmultipliedUnroundedRateValue.GetHashCode();
        }

        public Rate Clone()
        {
            return new Rate(UnitCurrency, RefCurrency, unmultipliedUnroundedRateValue, MetaData, RateConvention);
        }

        public int CompareTo(object obj)
        {
            var another = (Rate)obj;
            return unmultipliedUnroundedRateValue.CompareTo(another.unmultipliedUnroundedRateValue);
        }

        public decimal GetPointsSpreadTo(Rate toRate)
        {
            if (HasSameRateDirectionTo(toRate))
            {
                return unmultipliedUnroundedRateValue - toRate.unmultipliedUnroundedRateValue;
            }
            if (HasInversedRateDirectionTo(toRate))
            {
                return unmultipliedUnroundedRateValue - toRate.Inverted().unmultipliedUnroundedRateValue;
            }

            throw new InvalidOperationException("Currencies of two rates are not matched.");
        }

        public decimal GetPercentageSpreadTo(Rate toRate)
        {
            decimal pointsSpread = GetPointsSpreadTo(toRate);

            return Math.Abs((100 * pointsSpread) / unmultipliedUnroundedRateValue);
        }

        public static implicit operator decimal(Rate r)
        {
            return r.unmultipliedUnroundedRateValue;
        }

        public override string ToString()
        {
            return RoundedValue.ToString(CultureInfo.CurrentCulture.NumberFormat);
        }

        private bool HasSameRateDirectionTo(Rate rate)
        {
            return UnitCurrency == rate.UnitCurrency &&
                   RefCurrency == rate.RefCurrency;
        }

        private bool HasInversedRateDirectionTo(Rate rate)
        {
            return UnitCurrency == rate.RefCurrency &&
                   RefCurrency == rate.UnitCurrency;
        }

        public bool HasSameCurrencyPairAs(Rate rate2)
        {
            return UnitCurrency == rate2.UnitCurrency && RefCurrency == rate2.RefCurrency;
        }

        public Rate SetToConvention(RateConvention desiredRateConvention)
        {
            if (desiredRateConvention != RateConvention)
            {
                return Inverted();
            }
            return this;
        }

        public Rate SetToConventionAndRoundInTradersFavor(RateConvention newRateConvention, TradeDirection tradeDirection)
        {
            if (newRateConvention != RateConvention)
                this = Inverted();

            Rate computedRate;
            if ((tradeDirection == TradeDirection.Sell && IsDirect()) || (tradeDirection == TradeDirection.Buy && !IsDirect()))
                computedRate = NewValue(RoundUp(unmultipliedUnroundedRateValue, NumberOfDecimalsUnmultiplied));
            else
                computedRate = NewValue(RoundDown(unmultipliedUnroundedRateValue, NumberOfDecimalsUnmultiplied));

            return computedRate;
        }

        private static decimal RoundDown(decimal number, int decimalPlaces)
        {
            return Math.Floor(number * (IntPow(10, decimalPlaces))) / IntPow(10, decimalPlaces);
        }

        private static decimal RoundUp(decimal number, int decimalPlaces)
        {
            return Math.Ceiling(number * (IntPow(10, decimalPlaces))) / IntPow(10, decimalPlaces);
        }

        private static int IntPow(int a, int b)
        {
            int result = 1;
            for (int i = 0; i < b; i++)
                result *= a;
            return result;
        }
    }
}