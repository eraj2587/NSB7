﻿using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
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