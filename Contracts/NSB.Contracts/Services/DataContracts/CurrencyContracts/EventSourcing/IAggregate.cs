﻿using System.Collections.Generic;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.EventSourcing
{
    public interface IAggregate
    {
        long Id { get; }
        int Version { get; }
        void ApplyEvent(DomainEvent @event);

        IEnumerable<DomainEvent> UncommitedEvents();
        void ClearUncommitedEvents();
    }
}
