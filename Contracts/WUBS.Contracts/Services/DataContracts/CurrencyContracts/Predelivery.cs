using System;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    public class Predelivery : Contract
    {
        public Predelivery() : this(-1)
        { }

        public Predelivery(long id) : base(id)
        {
            RegisterTransition<PredeliveryBooked>(Apply);
        }

        public Predelivery(long id,
            ContractPricingComponent pricingComponent, Contract parentContract)
            : base(id, pricingComponent)
        {
            if (parentContract == null)
                throw new ArgumentNullException("parentContract");

            ParentContract = parentContract;
        }

        public override void Book()
        {
            RaiseEvent(new PredeliveryBooked()
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                BookingDate = BookingDate,
                PricingComponent = PricingComponent,
                CreatedAt = DateTime.Now,
                BookingPersonId = BookingPersonId,
                ForwardContractId = ParentContract.Id,
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

        public void Apply(PredeliveryBooked @event)
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