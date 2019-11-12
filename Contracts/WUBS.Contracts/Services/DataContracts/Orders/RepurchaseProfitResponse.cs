using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Orders
{
    [DataContract]
    public class RepurchaseProfitResponse
    {
        [DataMember]
        public Money NetWubsProfit { get; set; }
        [DataMember]
        public Money NetCustomerProfit { get; set; }
        [DataMember]
        public Dictionary<int, Money> LineItemProfitInTradeCurrency { get; set; }
    }
}