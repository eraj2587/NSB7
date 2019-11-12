using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.EventSourcing
{
    [DataContract]
    [Serializable]
    public class DomainEvent
    {
        [DataMember]
        public int Version { get; set; }
        [DataMember]
        public long AggregateId { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
