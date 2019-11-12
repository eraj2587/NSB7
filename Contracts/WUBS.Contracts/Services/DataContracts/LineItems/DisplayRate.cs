using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class DisplayRate
    {
        [DataMember]
        public bool IsDirect;

        [DataMember]
        public int NumberOfDecimalsDirect;

        [DataMember]
        public int NumberOfDecimalsIndirect;

        [DataMember]
        public decimal RateValue;

        [DataMember]
        public decimal InverseRateValue;

        [DataMember]
        public string ReferenceCurrencyCode;

        [DataMember]
        public string UnitCurrencyCode;
    }
}