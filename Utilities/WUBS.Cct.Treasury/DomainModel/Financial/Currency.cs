using System;
using Newtonsoft.Json;

namespace WUBS.Cct.Treasury.DomainModel.Financial
{
    [Serializable]
    public class Currency : IComparable
    {
        public static readonly Currency AUD = new Currency("AUD") { Description = "Australian Dollar", NumberOfDecimals = 2 };
        public static readonly Currency USD = new Currency("USD") { Description = "U.S.Dollar", NumberOfDecimals = 2 };
        public static readonly Currency CAD = new Currency("CAD") { Description = "Canadian Dollar", NumberOfDecimals = 2 };
        public static readonly Currency GBP = new Currency("GBP") { Description = "British Pound", NumberOfDecimals = 2 };
        public static readonly Currency INR = new Currency("INR") { Description = "Indian Rupee", NumberOfDecimals = 2, RoundToNearestValue = 0.1m };
        public static readonly Currency JPY = new Currency("JPY") { Description = "Japanese Yen", NumberOfDecimals = 0 };
        public static readonly Currency EUR = new Currency("EUR") { Description = "Euro", NumberOfDecimals = 2 };
        public static readonly Currency CHF = new Currency("CHF") { Description = "Swiss Franc", NumberOfDecimals = 2 };
        public static readonly Currency CNH = new Currency("CNH") { Description = "Chinese Offshore Yuan", NumberOfDecimals = 2 };
        public static readonly Currency IDR = new Currency("IDR") { Description = "Indonesian Rupiah", NumberOfDecimals = 0, RoundToNearestValue = 1 };
        public static readonly Currency Null = new Currency(string.Empty);

        public string Code { get; private set; }

        public string Description { get; set; }
        public int NumberOfDecimals { get; set; }
        public decimal MinimumTransactionAmount { get; set; }
        public decimal MaximumTransactionAmount { get; set; }
        public decimal RoundToNearestValue { get; set; }
        [JsonConstructor]
        public Currency(string code)
        {
            Code = FormatCurrencyCode(code);
            NumberOfDecimals = 2;
        }

        public Currency(string code, string description, int numberOfDecimals, decimal minimumTransactionAmount, decimal maximumTransactionAmount, decimal roundToNearestValue)
        {
            Code = code;
            Description = description;
            NumberOfDecimals = numberOfDecimals;
            MinimumTransactionAmount = minimumTransactionAmount;
            MaximumTransactionAmount = maximumTransactionAmount;
            RoundToNearestValue = roundToNearestValue;
        }

        public int CompareTo(object obj)
        {
            return Code.CompareTo(obj.ToString());
        }

        public override string ToString()
        {
            return Code;
        }

        public bool IsNoCentsCurrency()
        {
            return NumberOfDecimals == 0;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        public static bool operator !=(Currency one, Currency another)
        {
            return !(one == another);
        }

        public static implicit operator string(Currency currency)
        {
            return currency == null ? null : currency.ToString();
        }

        public static bool operator ==(Currency one, Currency another)
        {
            if ((object)one == null)
            {
                return (object)another == null;
            }

            return one.Equals(another);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Currency))
            {
                return false;
            }

            return Code == ((Currency)obj).Code;
        }

        private static string FormatCurrencyCode(string code)
        {
            return code.Trim().ToUpper();
        }

        public Money Money(decimal amount)
        {
            return new Money(this, amount);
        }
    }
}
