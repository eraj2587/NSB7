using System;
using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.EventSourcing;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class ContractEvent : DomainEvent
    {
        [DataMember]
        public Guid Id { get; set; }

        public long ContractId
        {
            get { return AggregateId; }
            set { AggregateId = value; }
        }
        [DataMember]
        public int EventUserId { get; set; }
    }
}