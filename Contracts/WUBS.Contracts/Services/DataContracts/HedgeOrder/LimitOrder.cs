using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts.LimitOrders
{
    [DataContract]
    public class LimitOrder
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string PublicOrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string CustomerAccount { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string PayeeId { get; set; }
        [DataMember]
        public PayeeType PayeeType { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string ContactFirstName { get; set; }
        [DataMember]
        public string ContactLastName { get; set; }
        [DataMember]
        public LimitOrderProcessType ProcessType { get; set; }
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public TradeDirection TradeDirection { get; set; }
        [DataMember]
        public Currency TradeCurrency { get; set; }
        [DataMember]
        public decimal TradeAmount { get; set; }
        [DataMember]
        public Currency SettlementCurrency { get; set; }
        [DataMember]
        public decimal SettlementAmount { get; set; }
        [DataMember]
        public DateTimeOffset? ExpiryDateTime { get; set; }
        [DataMember]
        public LimitOrderType OrderType { get; set; }
        [DataMember]
        public bool IsFilled { get; set; }
        [DataMember]
        public Rate FillRate { get; set; }
        [DataMember]
        public DateTimeOffset? FillDate { get; set; }
        [DataMember]
        public DateTimeOffset? FilledAt { get; set; }
        [DataMember]
        public string FilledBy { get; set; }
        [DataMember]
        public LimitOrderSupplier Supplier { get; set; }
        [DataMember]
        public string OfficeId { get; set; }
        [DataMember]
        public string ProcessCenterId { get; set; }
        [DataMember]
        public string ExternalSystem { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }
        [DataMember]
        public string AssignedTreasuryUser { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdatedAt { get; set; }
        [DataMember]
        public string LastUpdatedBy { get; set; }
        [DataMember]
        public string LastUpdatedByFirstName { get; set; }
        [DataMember]
        public string LastUpdatedByLastName { get; set; }
        [DataMember]
        public DateTimeOffset? LastApprovedAt { get; set; }
        [DataMember]
        public string LastApprovedBy { get; set; }
        [DataMember]
        public Channel Channel { get; set; }
        [DataMember]
        public Platform Platform { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public DateTimeOffset? RateRefreshDate { get; set; }
        [DataMember]
        public Maybe<LimitOrderRate> Rate { get; set; }
        [DataMember]
        public Maybe<LimitOrderRate> InverseRate { get; set; }


        [DataMember]
        public List<LimitOrderStatusLog> StatusLogs { get; set; }
        [DataMember]
        public bool IsTradeAmountFixed { get; set; }
    }

    [DataContract]
    public class LimitOrderHistory
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string PublicOrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string CustomerAccount { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string PayeeId { get; set; }
        [DataMember]
        public PayeeType PayeeType { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string ContactFirstName { get; set; }
        [DataMember]
        public string ContactLastName { get; set; }
        [DataMember]
        public LimitOrderProcessType ProcessType { get; set; }
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public TradeDirection TradeDirection { get; set; }
        [DataMember]
        public Currency TradeCurrency { get; set; }
        [DataMember]
        public decimal TradeAmount { get; set; }
        [DataMember]
        public Currency SettlementCurrency { get; set; }
        [DataMember]
        public decimal SettlementAmount { get; set; }
        [DataMember]
        public DateTimeOffset? ExpiryDateTime { get; set; }
        [DataMember]
        public LimitOrderType OrderType { get; set; }
        [DataMember]
        public bool IsFilled { get; set; }
        [DataMember]
        public Rate FillRate { get; set; }
        [DataMember]
        public DateTimeOffset? FillDate { get; set; }
        [DataMember]
        public DateTimeOffset? FilledAt { get; set; }
        [DataMember]
        public string FilledBy { get; set; }
        [DataMember]
        public LimitOrderSupplier Supplier { get; set; }
        [DataMember]
        public string OfficeId { get; set; }
        [DataMember]
        public string ProcessCenterId { get; set; }
        [DataMember]
        public string ExternalSystem { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }
        [DataMember]
        public string AssignedTreasuryUser { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdatedAt { get; set; }
        [DataMember]
        public string LastUpdatedBy { get; set; }
        [DataMember]
        public string LastUpdatedByFirstName { get; set; }
        [DataMember]
        public string LastUpdatedByLastName { get; set; }
        [DataMember]
        public DateTimeOffset? LastApprovedAt { get; set; }
        [DataMember]
        public string LastApprovedBy { get; set; }
        [DataMember]
        public Channel Channel { get; set; }
        [DataMember]
        public Platform Platform { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public DateTimeOffset? RateRefreshDate { get; set; }
        [DataMember]
        public List<LimitOrderAuditLogRates> Rate { get; set; }

        [DataMember]
        public List<LimitOrderStatusLog> StatusLogs { get; set; }
        [DataMember]
        public bool IsTradeAmountFixed { get; set; }
    }

    [DataContract]
    public class LimitOrderRate
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public OrderRateType RateType { get; set; }
        [DataMember]
        public Money UnitAmount { get; set; }
        [DataMember]
        public Money ReferenceAmount { get; set; }
        [DataMember]
        public Money DealerProfitInSettlementCurrency { get; set; }
        [DataMember]
        public Money DealerProfitInReportingCurrency { get; set; }
  
        [DataMember]
        public TradeDirection TradeDirection { get; set; }
        [DataMember]
        public Rate TriggerRate { get; set; }
        [DataMember]
        public Rate CustomerSpotRate { get; set; }
        [DataMember]
        public decimal CustomerMarkup { get; set; }
        [DataMember]
        public decimal CustomerForwardPoints { get; set; }
        [DataMember]
        public Rate MarketSpotRate { get; set; }
        [DataMember]
        public decimal MarketForwardPoints { get; set; }
        [DataMember]
        public Rate CostSpotRate { get; set; }
        [DataMember]
        public decimal CostSpread { get; set; }
        [DataMember]
        public decimal CostForwardPoints { get; set; }
        [DataMember]
        public DateTimeOffset Expiration { get; set; }
        [DataMember]
        public DateTimeOffset CostRateCalculatedOn { get; set; }
        [DataMember]
        public long QuoteId { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }
        [DataMember]
        public decimal OriginalCostSpread { get; set; }
        [DataMember]
        public Rate OriginalTriggerRate { get; set; }
        [DataMember]
        public short NDec { get; set; }
        [DataMember]
        public int RateMultiplier { get; set; }
        [DataMember]
        public decimal ChildEffectiveMultiplier { get; set; }
        [DataMember]
        public string RateString { get; set; }
        [DataMember]
        public Rate SettlementToReportingRate { get; set; }
        [DataMember]
        public Currency ReportingCurrency { get; set; }
        [DataMember]
        public decimal TreasuryAdjustment { get; set; }
    }

    [DataContract]
    public class LimitOrderNote
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public NoteType Type { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }

    }

    [DataContract]
    public class LimitOrderStatusLog
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public LimitOrderProcessType ProcessType { get; set; }
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public LimitOrderEvent Event { get; set; }
        [DataMember]
        public LimitOrderNote Note { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdatedAt { get; set; }
        [DataMember]
        public string LastUpdatedBy { get; set; }
        [DataMember]
        public string LastUpdatedByFirstName { get; set; }
        [DataMember]
        public string LastUpdatedByLastName { get; set; }
    }

    [DataContract]
    public class LimitOrderHistoryStatusLog
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public LimitOrderProcessType ProcessType { get; set; }
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public LimitOrderEvent Event { get; set; }
        [DataMember]
        public LimitOrderNote Note { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdatedAt { get; set; }
        [DataMember]
        public string LastUpdatedBy { get; set; }
        [DataMember]
        public string LastUpdatedByFirstName { get; set; }
        [DataMember]
        public string LastUpdatedByLastName { get; set; }
    }


    [DataContract]
    public class LimitOrderSupplier
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }

    }

    [DataContract]
    public class RateRefresh
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public DateTimeOffset RefreshDate { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }

    }

    [DataContract]
    public class LimitOrderMarketConvention
    {
        [DataMember] public string  BaseCurrency { get; set; }
        [DataMember] public string QuoteCurrency { get; set; }
        [DataMember] public string MarketConventionCurrencyPair { get; set; }
        [DataMember] public int CurrencyPairId { get; set; }

    }

    [DataContract]
    public class LimitOrderAuditLogRates
    {
        [DataMember]
        public LimitOrderAuditLogRate Rate { get; set; }
        [DataMember]
        public LimitOrderAuditLogRate InverseRate { get; set; }
    }

    [DataContract]
    public class LimitOrderAuditLogRate
    {
        [DataMember] public long LimitOrderRateAuditLogId { get; set; }
        [DataMember] public long LimitOrderRateId { get; set; }
        [DataMember] public string LimitOrderId { get; set; }
        [DataMember] public OrderRateType RateType { get; set; }
        [DataMember] public string TypeCode { get; set; }
        [DataMember] public string UnitCurrency { get; set; }
        [DataMember] public string ReferenceCurrency { get; set; }
        [DataMember] public Money UnitAmount { get; set; }
        [DataMember] public Money ReferenceAmount { get; set; }
        [DataMember] public Money DealerProfitInSettlementCurrency { get; set; }
        [DataMember]
        public Money DealerProfitInReportingCurrency { get; set; }

        [DataMember]
        public TradeDirection TradeDirection { get; set; }
        [DataMember]
        public Rate TriggerRate { get; set; }
        [DataMember]
        public Rate CustomerSpotRate { get; set; }
        [DataMember]
        public decimal CustomerMarkup { get; set; }
        [DataMember]
        public decimal CustomerForwardPoints { get; set; }
        [DataMember]
        public Rate MarketSpotRate { get; set; }
        [DataMember]
        public decimal MarketForwardPoints { get; set; }
        [DataMember]
        public Rate CostSpotRate { get; set; }
        [DataMember]
        public decimal CostSpread { get; set; }
        [DataMember]
        public decimal CostForwardPoints { get; set; }
        [DataMember]
        public DateTimeOffset Expiration { get; set; }
        [DataMember]
        public DateTimeOffset CostRateCalculatedOn { get; set; }
        [DataMember]
        public long QuoteId { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }
        [DataMember]
        public decimal OriginalCostSpread { get; set; }
        [DataMember]
        public Rate OriginalTriggerRate { get; set; }
        [DataMember]
        public short NDec { get; set; }
        [DataMember]
        public int RateMultiplier { get; set; }
        [DataMember]
        public decimal ChildEffectiveMultiplier { get; set; }
        [DataMember]
        public string RateString { get; set; }
        [DataMember]
        public Rate SettlementToReportingRate { get; set; }
        [DataMember]
        public Currency ReportingCurrency { get; set; }
        [DataMember]
        public decimal TreasuryAdjustment { get; set; }


    }
}
