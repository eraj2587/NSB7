using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Repurchase
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class QuoteRecord
    {
        [DataMember]
        public int QuoteId;

        [DataMember]
        public DateTime ExpirationDateTime;
    }
}