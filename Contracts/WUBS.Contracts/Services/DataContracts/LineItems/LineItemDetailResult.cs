﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class LineItemDetailResult
    {
        [DataMember] public IEnumerable<LineItemDetailResultItem> ItemList;
    }
}