﻿using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class Drawdown : Contract
    {
        public Drawdown() : this(-1)
        { }

        public Drawdown(long id) : base(id)
        {
            RegisterTransition<DrawdownBooked>(Apply);
        }

        public Drawdown(long id,
            ContractPricingComponent pricingComponent,
            Contract parentContract)
            : base(id, pricingComponent)
        {
            if (parentContract == null)
                throw new ArgumentNullException("parentContract");

            ParentContract = parentContract;
        }

        public override void Book()
        {
            RaiseEvent(new DrawdownBooked
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                BookingDate = BookingDate,
                PricingComponent = PricingComponent,
                CreatedAt = DateTime.UtcNow,
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

        public void Apply(DrawdownBooked @event)
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