using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class GetLineItemByPayerPayeeAccountRequest
    {
        [DataMember]
        public string Account;
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
