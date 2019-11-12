using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.EventSourcing
{
    [DataContract]
    [Serializable]
    public abstract class AggregateRoot : IAggregate
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        [DataMember]
        [NonSerialized]
        private List<DomainEvent> uncommitedEvents = new List<DomainEvent>();

        [DataMember]
        [NonSerialized]
        private List<DomainEvent> historicalEvents = new List<DomainEvent>();

        [NonSerialized]
        protected Dictionary<Type, Action<DomainEvent>> routes = new Dictionary<Type, Action<DomainEvent>>();

        private int version = -1;

        protected void RegisterTransition<T>(Action<T> transition) where T : class
        {
            if (routes == null)
                routes = new Dictionary<Type, Action<DomainEvent>>();

            routes.Add(typeof(T), o => transition(o as T));
        }

        protected void RaiseEvent(DomainEvent @event)
        {
            ApplyEvent(@event);
            uncommitedEvents.Add(@event);
        }

        public virtual void ApplyEvent(DomainEvent @event)
        {
            historicalEvents.Add(@event);

            var eventType = @event.GetType();
            if (routes.ContainsKey(eventType))
            {
                routes[eventType](@event);
            }
            Version++;
            @event.Version = Version;
        }

        public virtual IEnumerable<DomainEvent> UncommitedEvents()
        {
            return uncommitedEvents;
        }

        public virtual void ClearUncommitedEvents()
        {
            uncommitedEvents.Clear();
        }

        public virtual bool HasEvent<T>()
        {
            if (historicalEvents.Any(e => e.GetType() == typeof(T))) return true;
            if (uncommitedEvents.Any(e => e.GetType() == typeof(T))) return true;

            return false;
        }
    }
}
