using System;
using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Events;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.EventSourcing;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Pricing;
using NSB.Contracts.Services.DataContracts.CurrencyContracts.Time;
using NSB.Contracts.Services.DataContracts.Orders;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts
{
    [DataContract]
    [Serializable]
    [KnownType(typeof(NullContract))]
    [KnownType(typeof(SpotContract))]
    [KnownType(typeof(SpotContractBooked))]
    [KnownType(typeof(SpotContractAmended))]
    [KnownType(typeof(ForwardContract))]
    [KnownType(typeof(ForwardContractBooked))]
    [KnownType(typeof(ForwardContractAmended))]
    [KnownType(typeof(ForwardContractExtended))]
    [KnownType(typeof(Drawdown))]
    [KnownType(typeof(DrawdownBooked))]
    [KnownType(typeof(Predelivery))]
    [KnownType(typeof(PredeliveryBooked))]
    [KnownType(typeof(OffsetForwardContract))]
    [KnownType(typeof(OffsetForwardContractBooked))]
    [KnownType(typeof(ContractCancelled))]
    [KnownType(typeof(AutoSpotContract))]
    [KnownType(typeof(AutoForwardContract))]
    [KnownType(typeof(AutoContractDrawdown))]
    [KnownType(typeof(SingleSidedContractBooked))]
    [KnownType(typeof(SingleSidedContract))]
    public abstract class Contract : AggregateRoot
    {
        [DataMember]
        public virtual ContractPricingComponent PricingComponent { get; protected set; }
        [DataMember]
        public virtual int BookingPersonId { get; set; }
        [DataMember]
        public virtual int UpdatedByUserId { get; set; }
        [DataMember]
        public virtual DateTime LastUpdatedDate { get; set; }
        [DataMember]
        public virtual DateTime BookingDate { get; set; }
        [DataMember]
        public virtual string TradePartyReference1 { get; set; }
        [DataMember]
        public virtual string TradePartyReference2 { get; set; }

        public virtual Contract ParentContract { get; protected set; }

        protected bool initialized;

        public virtual void Initialize()
        {
            initialized = true;
        }

        protected Contract() : this(-1)
        {

        }

        protected Contract(long id)
        {
            Id = id;
            PricingComponent = new ContractPricingComponent();
        }

        protected Contract(long id, ContractPricingComponent pricingComponent)
            : this(id)
        {
            PricingComponent = pricingComponent;
        }

        protected Contract(long id, int version, ContractPricingComponent pricingComponent)
            : this(id, pricingComponent)
        {
            Version = version;
        }

        public virtual Money TradeVolume
        {
            get { return PricingComponent.TradeVolume; }
            protected set { PricingComponent.TradeVolume = value; }
        }

        public virtual Currency TradeCurrency
        {
            get { return TradeVolume != null ? TradeVolume.Currency : null; }
        }

        public virtual Money SettlementVolume
        {
            get { return PricingComponent.SettlementVolume; }
            protected set { PricingComponent.SettlementVolume = value; }
        }

        public virtual Currency SettlementCurrency
        {
            get { return SettlementVolume != null ? SettlementVolume.Currency : null; }
        }

        public virtual RateDirection RateDirection
        {
            get { return PricingComponent.RateDirection; }
            set { PricingComponent.RateDirection = value; }
        }

        public virtual Pricing.Rate TradingRate
        {
            get { return PricingComponent.CustomerSpotRate; }
        }

        public virtual TradeDirection TradeDirection
        {
            get { return PricingComponent.TradeDirection; }
        }

        public virtual Pricing.Rate CostPrice
        {
            get { return PricingComponent.CostSpotRate; }
        }

        public virtual Date StartingDate
        {
            get { return PricingComponent.StartEndDates.Start; }
        }

        public virtual Date EndingDate
        {
            get { return PricingComponent.StartEndDates.End; }
        }

        public abstract void Book();
        public abstract void Amend(decimal newTradeAmount, decimal newSettlementAmount, bool isAmountInSettlementCcy);
        public abstract void Amend(ContractPricingComponent newPricingComponent);

        public virtual void Cancel()
        {
            RaiseEvent(new ContractCancelled
            {
                Id = Guid.NewGuid(),
                ContractId = Id,
                CreatedAt = DateTime.Now
            });
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Contract))
            {
                return false;
            }

            Contract other = (Contract)obj;

            return
                Id == other.Id &&
                BookingDate == other.BookingDate &&
                StartingDate == other.StartingDate &&
                EndingDate == other.EndingDate &&
                TradeVolumeIsEqual(other) &&
                SettlementVolumeIsEqual(other) &&
                TradingRate == other.TradingRate &&
                CostPrice == other.CostPrice &&
                TradeCurrency == other.TradeCurrency &&
                SettlementCurrency == other.SettlementCurrency &&
                TradeDirection == other.TradeDirection &&
                RateDirection == other.RateDirection;
        }

        private bool TradeVolumeIsEqual(Contract other)
        {
            return TradeVolume == null
                ? TradeVolume == other.TradeVolume
                : TradeVolume.Currency == other.TradeVolume.Currency && TradeVolume.Amount == other.TradeVolume.Amount;
        }

        private bool SettlementVolumeIsEqual(Contract other)
        {
            return SettlementVolume == null
                ? SettlementVolume == other.SettlementVolume
                : SettlementVolume.Currency == other.SettlementVolume.Currency && SettlementVolume.Amount == other.SettlementVolume.Amount;
        }

        public virtual bool IsNullContract
        {
            get
            {
                return this as NullContract != null;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
