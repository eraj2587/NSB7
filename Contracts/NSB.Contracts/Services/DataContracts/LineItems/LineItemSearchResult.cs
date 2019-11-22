using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class LineItemSearchResult
    {
        [DataMember]
        public List<LineItemSearchResultItem> ItemList;

        [DataMember]
        public int TotalItems;
    }
}