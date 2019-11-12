using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.EventSourcing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class ContractCancelled : DomainEvent
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public long ContractId
        {
            get { return AggregateId; }
            set { AggregateId = value; }
        }
    }
}
