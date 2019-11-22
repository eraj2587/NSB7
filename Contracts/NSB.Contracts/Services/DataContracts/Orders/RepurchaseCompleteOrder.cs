using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class RepurchaseCompleteOrder : CompleteOrder
    {
        [DataMember]
        public string OriginalOrderId { get; set; }
    }

    [DataContract]
    public class RepurchaseCompleteLineItem : CompleteLineItem
    {
        [DataMember]
        public int OriginalLineItemId { get; set; }
        [DataMember]
        public Rate OriginalCustomerRate { get; set; }
        [DataMember]
        public Rate OriginalInvertedCustomerRate { get; set; }
        [DataMember]
        public Rate OriginalCostRate { get; set; }
        [DataMember]
        public Money OriginalSettlement { get; set; }
    }
}