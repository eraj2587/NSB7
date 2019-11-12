using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CustomerContracts
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class CustomerAccountInfoSearchResult
    {
        [DataMember]
        public IEnumerable<CustomerAccountInfoSearchResultItem> ItemList;
    }
}
