using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing
{
    [Serializable]
    [DataContract]
    public struct Rate : IComparable
    {
        private const int tradingRateMeaningfulDigits = 12;
        [JsonProperty]
        [DataMember]
        private readonly decimal unmultipliedUnroundedRateValue;
        [DataMember]
        public readonly Currency UnitCurrency; //base,transaction
        [DataMember]
        public readonly Currency RefCurrency; //quote,price,
        [DataMember]
        public readonly int significantDigits;

        public decimal RoundedValue
        {
            get { return Math.Round(unmultipliedUnroundedRateValue, significantDigits, MidpointRounding.AwayFromZero); }
        }

        public static readonly Rate NullRate = new Rate(Currency.Null, Currency.Null, 0);

        public Rate(Currency unitCurrency,
            Currency refCurrency,
            decimal value)
        {
            UnitCurrency = unitCurrency;
            RefCurrency = refCurrency;
            unmultipliedUnroundedRateValue = value;
            significantDigits = tradingRateMeaningfulDigits;
        }

        public Rate(Currency unitCurrency,
        Currency refCurrency,
        decimal value,
        int noOfDecimals)
        {
            UnitCurrency = unitCurrency;
            RefCurrency = refCurrency;
            unmultipliedUnroundedRateValue = value;
            significantDigits = noOfDecimals;
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

            return new Rate(RefCurrency, UnitCurrency, inverseValue, significantDigits);
        }

        public Rate NewValue(decimal newValue)
        {
            return new Rate(UnitCurrency, RefCurrency, newValue, significantDigits);
        }

        public Rate Round()
        {
            return new Rate(UnitCurrency, RefCurrency, RoundedValue, significantDigits);
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
            return new Rate(UnitCurrency, RefCurrency, unmultipliedUnroundedRateValue, significantDigits);
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
            return UnitCurrency.Code == rate2.UnitCurrency.Code && RefCurrency.Code == rate2.RefCurrency.Code;
        }
    }
}