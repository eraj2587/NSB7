using System;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Events;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts
{
    [Serializable]
    public class ForwardContract : Contract
    {
        public bool IsAggregated { get; private set; }

        public   string OptionContractId { get; set; }

        public   int? OptionLeg { get; set; }

        public ForwardContract() : this(-1)
        {
            Initialize();
        }

        public ForwardContract(long id) : base(id)
        { }

        public ForwardContract(long id, ContractPricingComponent pricingComponent, bool isAggregated)
            : base(id, pricingComponent)
        {
            IsAggregated = isAggregated;
        }

        public ForwardContract(long id, int version, ContractPricingComponent pricingComponent, bool isAggregated, string optionContractId, int? optionLeg)
            : base(id, pricingComponent)
        {
            Version = version;
            IsAggregated = isAggregated;
            this.OptionLeg = optionLeg;
            this.OptionContractId = optionContractId;
        }

        public decimal ForwardPoints { get { return PricingComponent.CostForwardPoints; } }

        public override void Initialize()
        {
            if (!initialized)
            {
                base.Initialize();
                RegisterTransition<ForwardContractBooked>(Apply);
                RegisterTransition<ForwardContractAmended>(Apply);
                RegisterTransition<ForwardContractExtended>(Apply);
            }
        }

        public override void Book()
        {
            RaiseEvent(new ForwardContractBooked
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                BookingDate = BookingDate,
                CreatedAt = DateTime.Now,
                BookingPersonId = BookingPersonId,
                OptionLeg =  OptionLeg,
                OptionContractId =  OptionContractId,
                PricingComponent = PricingComponent
            });
        }

        public override void Amend(decimal newTradeAmount, decimal newSettlementAmount, bool isAmountInSettlementCcy)
        {
            TradeVolume = new Money(TradeVolume.Currency, newTradeAmount);
            SettlementVolume = new Money(SettlementCurrency, newSettlementAmount);
            PricingComponent.IsAmountInSettlementCurrency = isAmountInSettlementCcy;
            
            RaiseEvent(new ForwardContractAmended
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                CreatedAt = DateTime.Now,
                NewPricingComponent = PricingComponent
            });
        }

        public override void Amend(ContractPricingComponent newPricingComponent)
        {
            PricingComponent = newPricingComponent;

            RaiseEvent(new ForwardContractAmended
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                CreatedAt = DateTime.Now,
                NewPricingComponent = PricingComponent
            });
        }

        public void Extend(ContractPricingComponent extensionPricingComponent)
        {
            PricingComponent = extensionPricingComponent;

            RaiseEvent(new ForwardContractExtended
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                NewPricingComponent = PricingComponent,
                CreatedAt = DateTime.Now,
                IsAggregated = IsAggregated,
            });
        }

        public void Apply(ForwardContractBooked @event)
        {
            Id = @event.ContractId;
            PricingComponent = @event.PricingComponent;
            BookingDate = @event.BookingDate;
            BookingPersonId = @event.BookingPersonId;
            LastUpdatedDate = @event.CreatedAt;
            UpdatedByUserId = @event.EventUserId;
        }

        public void Apply(ForwardContractAmended @event)
        {
            Id = @event.ContractId;
            PricingComponent = @event.NewPricingComponent;
            LastUpdatedDate = @event.CreatedAt;
            UpdatedByUserId = @event.EventUserId;
        }

        public void Apply(ForwardContractExtended @event)
        {
            Id = @event.ContractId;
            PricingComponent = @event.NewPricingComponent;
            LastUpdatedDate = @event.CreatedAt;
            UpdatedByUserId = @event.EventUserId;
        }
    }
}