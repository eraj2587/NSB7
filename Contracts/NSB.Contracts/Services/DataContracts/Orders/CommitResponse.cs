using System;
using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.Orders;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class CommitResponse
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public OrderStatus StatusId { get; set; }

        [DataMember]
        public DateTimeOffset OrderCreatedOn { get; set; }
    }
}
