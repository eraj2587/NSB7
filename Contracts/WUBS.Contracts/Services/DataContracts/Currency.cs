using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{

    [DataContract]
    [Serializable]
    public class Currency
    {
        public static readonly Currency Null = new Currency(string.Empty);
        private string code;

        public Currency() { }

        public Currency(string currencyCode)
        {
            if (currencyCode != null)
                Code = currencyCode.ToUpper();
        }

        [DataMember]
        public string Code
        {
            get { return code; }
            set { code = value == null ? null : value.ToUpper(); }
        }

        [DataMember]
        public int NumberOfDecimals { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }

    [DataContract]
    [Serializable]
    public class CurrencyDetails : Currency
    {

        public CurrencyDetails() { }
        public CurrencyDetails(string currencyCode) : base(currencyCode) { }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public decimal MinimumTransactionAmount { get; set; }

        [DataMember]
        public decimal MaximumTransactionAmount { get; set; }

        [DataMember]
        public decimal RoundToNearestValue { get; set; }
    }
}
