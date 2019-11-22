using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class MassPaySearchResult
    {
        [DataMember] public IEnumerable<MassPaySearchResultItem> ItemList;
        [DataMember] public int TotalItems;
    }
}