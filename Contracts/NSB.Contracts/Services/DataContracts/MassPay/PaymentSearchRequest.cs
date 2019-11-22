using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class PaymentSearchRequest
    {
        [DataMember] public string PartnerCustomerId;
        [DataMember] public decimal? Amount;
        [DataMember] public string Currency;
        [DataMember] public DateTime? StartDate;
        [DataMember] public DateTime? EndDate;
        [DataMember] public int MaxResults;
    }
}
