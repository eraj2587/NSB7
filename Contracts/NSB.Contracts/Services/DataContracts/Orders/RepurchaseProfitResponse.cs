using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Orders
{
    [DataContract]
    public class RepurchaseProfitResponse
    {
        [DataMember]
        public Money NetNSBProfit { get; set; }
        [DataMember]
        public Money NetCustomerProfit { get; set; }
        [DataMember]
        public Dictionary<int, Money> LineItemProfitInTradeCurrency { get; set; }
    }
}