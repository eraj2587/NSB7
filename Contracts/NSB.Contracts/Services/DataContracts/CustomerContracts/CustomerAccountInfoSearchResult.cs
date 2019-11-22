using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CustomerContracts
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class CustomerAccountInfoSearchResult
    {
        [DataMember]
        public IEnumerable<CustomerAccountInfoSearchResultItem> ItemList;
    }
}
