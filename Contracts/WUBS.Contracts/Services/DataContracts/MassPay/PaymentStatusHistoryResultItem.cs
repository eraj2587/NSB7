using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class PaymentStatusHistoryResultItem 
    {
        [DataMember]
        public DateTime UpdatedOnUtc { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string ReasonText { get; set; }

        [DataMember]
        public string ReasonCode { get; set; }

        [DataMember]
        public decimal? ReturnedAmount { get; set;}

        [DataMember]
        public string ReturnedCurrency { get; set; }

        public bool IsReturnedHistory()
        {
            return !string.IsNullOrEmpty(Status) && Status.Equals("Returned");
        }
    }
}