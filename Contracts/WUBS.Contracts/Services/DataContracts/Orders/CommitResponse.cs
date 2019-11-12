using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts
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
