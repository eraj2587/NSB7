using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class OffsetForwardContract : ForwardContract
    {
        public bool IsPredeliveryRepoOrFwdSaleRepo { get; private set; }

        public OffsetForwardContract() : this(-1)
        {
            Initialize();
        }

        public OffsetForwardContract(long id) : base(id)
        { }

        public OffsetForwardContract(long id, ContractPricingComponent pricingComponent, bool isAggregated, bool isPredeliveryRepoOrFwdSaleRepo)
            : base(id, pricingComponent, isAggregated)
        {
            IsPredeliveryRepoOrFwdSaleRepo = isPredeliveryRepoOrFwdSaleRepo;
        }

        public OffsetForwardContract(long id, int version, ContractPricingComponent pricingComponent, bool isAggregated, bool isPredeliveryRepoOrFwdSaleRepo)
            : base(id, version, pricingComponent, isAggregated , string.Empty,null)
        {
            IsPredeliveryRepoOrFwdSaleRepo = isPredeliveryRepoOrFwdSaleRepo;
        }

        public override void Initialize()
        {
            if (!initialized)
            {
                base.Initialize();
                RegisterTransition<OffsetForwardContractBooked>(Apply);
            }
        }

        public override void Book()
        {
            RaiseEvent(new OffsetForwardContractBooked
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                BookingDate = BookingDate,
                CreatedAt = DateTime.Now,
                BookingPersonId = BookingPersonId,
                PricingComponent = PricingComponent,
                IsPredeliveryRepoOrFwdSaleRepo = IsPredeliveryRepoOrFwdSaleRepo
            });
        }

        public void Apply(OffsetForwardContractBooked @event)
        {
            Id = @event.ContractId;
            PricingComponent = @event.PricingComponent;
            BookingDate = @event.BookingDate;
            BookingPersonId = @event.BookingPersonId;
            LastUpdatedDate = @event.CreatedAt;
            UpdatedByUserId = @event.EventUserId;
            IsPredeliveryRepoOrFwdSaleRepo = @event.IsPredeliveryRepoOrFwdSaleRepo;
        }
    }
}
