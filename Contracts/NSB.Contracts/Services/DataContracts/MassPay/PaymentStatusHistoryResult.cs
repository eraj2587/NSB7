using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class PaymentStatusHistoryResult
    {
        [DataMember]
        public IEnumerable<PaymentStatusHistoryResultItem> ItemList;
        [DataMember]
        public int TotalItems;
    }
}