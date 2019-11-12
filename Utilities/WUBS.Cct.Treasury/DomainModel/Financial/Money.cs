using System;
using Newtonsoft.Json;

namespace WUBS.Cct.Treasury.DomainModel.Financial
{
    [Serializable]
    public struct Money : IComparable
    {
        public static readonly Money Null = new Money(null, 0m);
        private readonly Currency currency;
        private readonly decimal amount;
        [JsonConstructor]
        public Money(Currency currency, decimal amount)
        {
            var roundedAmount = amount;

            if (currency != null && currency.RoundToNearestValue != 0)
                roundedAmount = Math.Round(amount / currency.RoundToNearestValue, MidpointRounding.AwayFromZero) * currency.RoundToNearestValue;

            this.amount = currency == null ? roundedAmount : Math.Round(roundedAmount, currency.NumberOfDecimals, MidpointRounding.AwayFromZero);
            this.currency = currency;
        }

        public Currency Currency
        {
            get { return currency; }
        }

        public decimal Amount
        {
            get { return amount; }
        }

        public Money Copy()
        {
            return new Money(Currency, Amount);
        }

        public Money NewMoney(decimal newAmount)
        {
            return new Money(Currency, newAmount);
        }

        public Money Add(decimal amountToAdd)
        {
            return new Money(Currency, Amount + amountToAdd);
        }

        public Money Add(Money money)
        {
            if (money.IsNull)
                return new Money(currency, amount);

            if (IsNull)
                return new Money(money.currency, money.amount);

            VerifyMoneyHasSameCurrency(money);
            return new Money(Currency, Amount + money.amount);
        }

        public Money Subtract(decimal amountToSubtract)
        {
            return new Money(Currency, Amount - amountToSubtract);
        }

        public Money Subtract(Money money)
        {
            if (money.IsNull)
                return new Money(currency, amount);

            if (IsNull)
                return money.Negated();

            VerifyMoneyHasSameCurrency(money);
            return new Money(Currency, Amount - money.amount);
        }

        public static Money operator +(Money one, Money another)
        {
            return one.Add(another);
        }

        public static Money operator -(Money one, Money another)
        {
            return one.Subtract(another);
        }

        public static bool operator <(Money one, Money another)
        {
            one.VerifyMoneyHasSameCurrency(another);
            return one.Amount < another.Amount;
        }

        public static bool operator >(Money one, Money another)
        {
            one.VerifyMoneyHasSameCurrency(another);
            return one.Amount > another.Amount;
        }

        public static bool operator >=(Money one, Money another)
        {
            one.VerifyMoneyHasSameCurrency(another);
            return one.Amount >= another.Amount;
        }

        public static bool operator <=(Money one, Money another)
        {
            one.VerifyMoneyHasSameCurrency(another);
            return one.Amount <= another.Amount;
        }

        public static bool operator ==(Money one, Money another)
        {
            return one.Equals(another);
        }

        public static bool operator !=(Money one, Money another)
        {
            return !one.Equals(another);
        }

        public override int GetHashCode()
        {
            return amount.GetHashCode() ^ Currency.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Money))
                return false;

            var another = (Money)obj;

            return Amount == another.Amount && Currency == another.Currency;
        }

        public override string ToString()
        {
            return ((currency == null) ? string.Empty : Currency.ToString()) + ' ' + Amount;
        }

        public static Money Min(Money one, Money another)
        {
            if (one < another)
                return one;

            return another;
        }

        public Money Negated()
        {
            return new Money(currency, -amount);
        }

        public Money Absolute()
        {
            if (IsNull) return this;
            return new Money(currency, Math.Abs(amount));
        }

        public bool IsPositive
        {
            get { return amount > 0; }
        }

        public bool IsNegative
        {
            get { return amount < 0; }
        }

        public bool IsZero
        {
            get { return amount == 0; }
        }

        public bool IsNull
        {
            get { return this == Null; }
        }

        public void VerifyMoneyHasSameCurrency(Money money)
        {
            if (!Currency.Equals(money.Currency))
                throw new ArgumentException("Incorrect currency. Money currencies do not match " + this + " <-> " + money);
        }

        // Implements IComparable interface
        public int CompareTo(object obj)
        {
            var money = (Money)obj;
            return Amount.CompareTo(money.Amount);
        }

        public Money RoundAmount()
        {
            return new Money(currency, Math.Round(amount, currency.NumberOfDecimals));
        }
    }
}
