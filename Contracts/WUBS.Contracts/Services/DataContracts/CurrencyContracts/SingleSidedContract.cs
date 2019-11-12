using System;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    [Serializable]
    public class SingleSidedContract : Contract
    {
        public SingleSidedContract() : this(-1)
        {
            Initialize();
        }

        public SingleSidedContract(long id) : base(id)
        { }

        public SingleSidedContract(long id, int version, ContractPricingComponent pricingComponent) : base(id, pricingComponent)
        {
            Version = version;
        }

        public override void Initialize()
        {
            if (!initialized)
            {
                base.Initialize();
                RegisterTransition<SingleSidedContractBooked>(Apply);
            }
        }

        public override void Book()
        {
            RaiseEvent(new SingleSidedContractBooked
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                BookingDate = BookingDate,
                CreatedAt = DateTime.Now,
                BookingPersonId = BookingPersonId,
                PricingComponent = PricingComponent
            });
        }

        public override void Amend(decimal newTradeAmount, decimal newSettlementAmount, bool isAmountInSettlementCcy)
        {
            throw new NotImplementedException();
        }

        public override void Amend(ContractPricingComponent newPricingComponent)
        {
            throw new NotImplementedException();
        }

        public void Apply(SingleSidedContractBooked @event)
        {
            Id = @event.ContractId;
            PricingComponent = @event.PricingComponent;
            BookingDate = @event.BookingDate;
            BookingPersonId = @event.BookingPersonId;
            LastUpdatedDate = @event.CreatedAt;
            UpdatedByUserId = @event.EventUserId;
        }

    }
}
