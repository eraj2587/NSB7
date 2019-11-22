using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class PaymentDetailsResult
    {
        [DataMember] public IEnumerable<PaymentDetailsResultItem> ItemList;
    }
}