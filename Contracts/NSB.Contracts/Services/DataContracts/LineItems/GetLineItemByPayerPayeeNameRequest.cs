using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class GetLineItemByPayerPayeeNameRequest
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int? ProcessingCenterId;
        [DataMember]
        public DateTime? StartDate;
        [DataMember]
        public DateTime? EndDate;
        [DataMember]
        public int MaxResults;
        [DataMember]
        public string CurrencyCode;
        [DataMember]
        public decimal? AmountFrom;
        [DataMember]
        public decimal? AmountTo;

    }
}
