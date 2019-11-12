using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    public class SpotContract : Contract
    {
        public SpotContract() : this(-1)
        {
            Initialize();
        }

        public SpotContract(long id) : base(id)
        {
        }

        public   string OptionContractId { get; set; }
        public   int? OptionLeg { get; set; }

        public SpotContract(long id, ContractPricingComponent pricingComponent)
            : base(id, pricingComponent)
        { }

        public SpotContract(long id, int version, ContractPricingComponent pricingComponent, string optionContractId ,int? optionLeg)
            : base(id, version, pricingComponent)
        {
            this.OptionContractId = optionContractId;
            this.OptionLeg = OptionLeg;
        }

        public override void Initialize()
        {
            if (!initialized)
            {
                base.Initialize();
                RegisterTransition<SpotContractBooked>(Apply);
                RegisterTransition<SpotContractAmended>(Apply);
            }
        }

        public override void Book()
        {
            RaiseEvent(new SpotContractBooked
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                PricingComponent = PricingComponent,
                OptionLeg = OptionLeg,
                OptionContractId = OptionContractId,
                CreatedAt = DateTime.UtcNow,
            });
        }

        public void Apply(SpotContractAmended @event)
        {
            Id = @event.ContractId;
            PricingComponent = @event.NewPricingComponent;
            LastUpdatedDate = @event.CreatedAt;
            UpdatedByUserId = @event.EventUserId;
        }

        public void Apply(SpotContractBooked @event)
        {
            Id = @event.ContractId;
            PricingComponent = @event.PricingComponent;
            BookingDate = @event.BookingDate;
            LastUpdatedDate = @event.CreatedAt;
            UpdatedByUserId = @event.EventUserId;
        }

        public override void Amend(decimal newTradeAmount, decimal newSettlementAmount, bool isAmountInSettlementCcy)
        {
            TradeVolume = new Money(TradeVolume.Currency, newTradeAmount);
            SettlementVolume = new Money(SettlementCurrency, newSettlementAmount);
            PricingComponent.IsAmountInSettlementCurrency = isAmountInSettlementCcy;

            RaiseEvent(new SpotContractAmended
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                CreatedAt = DateTime.UtcNow,
                NewPricingComponent = PricingComponent
            });
        }

        public override void Amend(ContractPricingComponent newPricingComponent)
        {
            PricingComponent = newPricingComponent;

            RaiseEvent(new SpotContractAmended
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                NewPricingComponent = PricingComponent,
                CreatedAt = DateTime.UtcNow,
            });
        }
    }
}