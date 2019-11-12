using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class MassPaySearchResult
    {
        [DataMember] public IEnumerable<MassPaySearchResultItem> ItemList;
        [DataMember] public int TotalItems;
    }
}