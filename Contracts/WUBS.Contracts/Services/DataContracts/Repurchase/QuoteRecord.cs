using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Repurchase
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class QuoteRecord
    {
        [DataMember]
        public int QuoteId;

        [DataMember]
        public DateTime ExpirationDateTime;
    }
}