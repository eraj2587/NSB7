using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public abstract class LimitOrderResponse
    {
        [DataMember]
        public string OrderId { get; set; }
    }

    [DataContract]
    public class LimitOrderRefreshQueryResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public DateTimeOffset? RateRefreshDate { get; set; }
    }

    [DataContract]
    public class LimitOrderBuildResponse : LimitOrderResponse
    {

    }

    [DataContract]
    public class LimitOrderModifyTreasuryResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public string SupplierName { get; set; }
        [DataMember]
        public Rate TriggerRate { get; set; }

    }


    [DataContract]
    public class LimitOrderSubmitResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderBuildAndSubmitResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
    }

    [DataContract]
    public class LimitOrderApproveResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderRejectResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderCancelResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public DateTimeOffset StatusChangeDate { get; set; }
    }

    [DataContract]
    public class LimitOrderApproveCancelResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderRejectCancelResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderModifyResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderFillResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
    }

    [DataContract]
    public class LimitOrderApproveExpiryResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderRejectExpiryResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderQuoteResponse
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string PublicOrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string TradeCurrency { get; set; }
        [DataMember]
        public decimal TradeAmount { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public decimal SettlementAmount { get; set; }
        [DataMember]
        public TradeDirection TradeDirection { get; set; }
        [DataMember]
        public RateResponse Rate { get; set; }
        [DataMember]
        public RateResponse InverseRate { get; set; }

    }

    [DataContract]
    public class RateResponse
    {
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
        public Rate TriggerRate { get; set; }
        [DataMember]
        public decimal DealerProfitinSettlementCurrency { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public decimal DealerProfitinReportingCurrency { get; set; }
        [DataMember]
        public Rate SettlementToReportingRate { get; set; }
        [DataMember]
        public string ReportingCurrency { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public decimal TreasuryAdjustment { get; set; }
    }

    [DataContract]
    public class LimitOrderCalculateResponse : LimitOrderQuoteResponse
    {

    }

    public class LimitOrderStatusChangeResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    public class LimitOrderDeleteResponse : LimitOrderResponse
    {
        [DataMember]
        public bool Deleted { get; set; }
    }

    public class LimitOrderChangeTypeResponse : LimitOrderResponse
    {
        [DataMember]
        public LimitOrderProcessType Type { get; set; }
        [DataMember]
        public LimitOrderStatus Status { get; set; }
    }

    [DataContract]
    public class LimitOrderSearchResult : LimitOrderResponse
    {
        [DataMember]
        public IEnumerable<LimitOrderSearchItem> ItemList;
    }



    [DataContract]
    public class LimitOrderSearchItem
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string PublicOrderId { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string Payee { get; set; }
        [DataMember]
        public string PayeeType { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string ProcessType { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string TradeDirection { get; set; }
        [DataMember]
        public string OrderType { get; set; }
        [DataMember]
        public string TradeCurrency { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public string TradeAmount { get; set; }
        [DataMember]
        public string SettlementAmount { get; set; }
        [DataMember]
        public string ExpiryDate { get; set; }
        [DataMember]
        public string TriggerRate { get; set; }
        [DataMember]
        public string FillRate { get; set; }
        [DataMember]
        public string AssignedTreasuryUser { get; set; }
        [DataMember]
        public string ProcessCenter { get; set; }
        [DataMember]
        public string Office { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string LastUpdatedBy { get; set; }
        [DataMember]
        public string LastApprovedBy { get; set; }
        [DataMember]
        public string Channel { get; set; }
        [DataMember]
        public string Platform { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public string Product { get; set; }
    }

    [DataContract]
    public class GetLimitOrderSearchResponse
    {
        [DataMember]
        public List<LimitOrderSearchResponse> LimitOrderSearchList { get; set; }
        [DataMember]
        public long CurrentPage { get; set; }
        [DataMember]
        public long OrdersPerPage { get; set; }
        [DataMember]
        public long TotalPages { get; set; }

        [DataMember]
        public long TotalOrders { get; set; }
    }

    [DataContract]
    public class LimitOrderSearchResponse : LimitOrderResponse
    {
        [DataMember]
        public string PublicOrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string CustomerAccount { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string ProcessType { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string TradeDirection { get; set; }
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
        public string OrderType { get; set; }
        [DataMember]
        public string OfficeDescription { get; set; }
        [DataMember]
        public string OfficeCode { get; set; }
        [DataMember]
        public string CreatedAt { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdatedAt { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
        [DataMember]
        public Rate TriggerRate { get; set; }
        [DataMember]
        public Rate CustomerSpotRate { get; set; }
        [DataMember]
        public Rate CostSpotRate { get; set; }
        [DataMember]
        public DateTimeOffset? RateRefreshDate { get; set; }
        [DataMember]
        public string SupplierName { get; set; }
        [DataMember]
        public decimal TreasuryAdjustment { get; set; }
        [DataMember]
        public decimal CustomerMarkup { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public string ContactFirstName { get; set; }
        [DataMember]
        public string ContactLastName { get; set; }
    }

    [DataContract]
    public class LimitOrderDetailResponse : LimitOrderResponse
    {
        [DataMember]
        public string PublicOrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string CustomerAccount { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public LimitOrderSupplierResponse Supplier { get; set; }
        [DataMember]
        public string PayeeId { get; set; }
        [DataMember]
        public string PayeeType { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string ContactFirstName { get; set; }
        [DataMember]
        public string ContactLastName { get; set; }
        [DataMember]
        public string ProcessType { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string TradeDirection { get; set; }
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
        public string OrderType { get; set; }
        [DataMember]
        public string OfficeId { get; set; }
        [DataMember]
        public string Office { get; set; }
        [DataMember]
        public string ProcessCenterId { get; set; }
        [DataMember]
        public string ProcessCenter { get; set; }
        [DataMember]
        public string ExternalSystem { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }
        [DataMember]
        public string CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }
        [DataMember]
        public string LastUpdatedAt { get; set; }
        [DataMember]
        public string LastUpdatedBy { get; set; }
        [DataMember]
        public string LastUpdatedByFirstName { get; set; }
        [DataMember]
        public string LastUpdatedByLastName { get; set; }
        [DataMember]
        public string Channel { get; set; }
        [DataMember]
        public string Platform { get; set; }
        [DataMember]
        public string Product { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public LimitOrderRateResponse Rate { get; set; }
        [DataMember]
        public List<LimitOrderStatusLogResponse> StatusLogs { get; set; }
        [DataMember]
        public DateTimeOffset RateRefreshDate { get; set; }

        [DataMember]
        public LimitOrderRateResponse InverseRate { get; set; }
    }


    [DataContract]
    public class LimitOrderDetailHistoryResponse : LimitOrderResponse
    {
        [DataMember]
        public string PublicOrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string CustomerAccount { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public LimitOrderSupplierResponse Supplier { get; set; }
        [DataMember]
        public string PayeeId { get; set; }
        [DataMember]
        public string PayeeType { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string ContactFirstName { get; set; }
        [DataMember]
        public string ContactLastName { get; set; }
        [DataMember]
        public string ProcessType { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string TradeDirection { get; set; }
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
        public string OrderType { get; set; }
        [DataMember]
        public string OfficeId { get; set; }
        [DataMember]
        public string Office { get; set; }
        [DataMember]
        public string ProcessCenterId { get; set; }
        [DataMember]
        public string ProcessCenter { get; set; }
        [DataMember]
        public string ExternalSystem { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }
        [DataMember]
        public string CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string CreatedByFirstName { get; set; }
        [DataMember]
        public string CreatedByLastName { get; set; }
        [DataMember]
        public string LastUpdatedAt { get; set; }
        [DataMember]
        public string LastUpdatedBy { get; set; }
        [DataMember]
        public string LastUpdatedByFirstName { get; set; }
        [DataMember]
        public string LastUpdatedByLastName { get; set; }
        [DataMember]
        public string Channel { get; set; }
        [DataMember]
        public string Platform { get; set; }
        [DataMember]
        public string Product { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public List<LimitOrderRatesHistoryResponse> Rate { get; set; }
        [DataMember]
        public List<LimitOrderStatusLogResponse> StatusLogs { get; set; }
        [DataMember]
        public DateTimeOffset RateRefreshDate { get; set; }

    }

    [DataContract]
    public class LimitOrderSupplierResponse
    {
        [DataMember]
        public long SupplierId { get; set; }

        [DataMember]
        public string SupplierName { get; set; }
    }

    public class LimitOrderStatusLogResponse
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
        public LimitOrderNotesResponse Note { get; set; }
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
    public class LimitOrderRateResponse
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public OrderRateType RateType { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public string TradeCurrency { get; set; }
        [DataMember]
        public string ReportingCurrency { get; set; }
        [DataMember]
        public decimal SettlementAmount { get; set; }
        [DataMember]
        public decimal TradeAmount { get; set; }
        [DataMember]
        public decimal DealerProfitinSettlementCurrency { get; set; }
        [DataMember]
        public decimal DealerProfitinReportingCurrency { get; set; }
        [DataMember]
        public Rate SettlementToReportingRate { get; set; }
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
        public decimal TreasuryAdjustment { get; set; }
    }

    [DataContract]
    public class LimitOrderRatesHistoryResponse
    {
        [DataMember] public LimitOrderRateHistoryResponse Rate { get; set; }
        [DataMember] public LimitOrderRateHistoryResponse InverseRate { get; set; }
    }

    [DataContract]
    public class LimitOrderRateHistoryResponse
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public OrderRateType RateType { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public string TradeCurrency { get; set; }
        [DataMember]
        public string ReportingCurrency { get; set; }
        [DataMember]
        public decimal SettlementAmount { get; set; }
        [DataMember]
        public decimal TradeAmount { get; set; }
        [DataMember]
        public decimal DealerProfitinSettlementCurrency { get; set; }
        [DataMember]
        public decimal DealerProfitinReportingCurrency { get; set; }
        [DataMember]
        public Rate SettlementToReportingRate { get; set; }
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
        public decimal TreasuryAdjustment { get; set; }

       
    }



    [DataContract]
    public class LimitOrderNotesResponse
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
    public class ReCalculateTriggerRatesResponse
    {
        [DataMember]
        public bool ReCalculateInitiated { get; set; }
    }

    [DataContract]
    public class GetLimitOrderSearchRefreshResponse
    {
        [DataMember]
        public List<LimitOrderSearchResponse> LimitOrderSearchList { get; set; }

        [DataMember]
        public long TotalOrders { get; set; }
    }

    [DataContract]
    public class LimitOrderStatisticsReportResponse
    {
        [DataMember]
        public string TotalOrdersEntered { get; set; }
        [DataMember]
        public string TotalOrdersActive { get; set; }
        [DataMember]
        public string TotalOrdersFilled { get; set; }
        [DataMember]
        public string TotalOrdersExpired { get; set; }
        [DataMember]
        public string TotalOrdersCancelled { get; set; }
        [DataMember]
        public string TotalOrdersManualProcessed { get; set; }
        [DataMember]
        public string TotalOrdersAutoProcessed { get; set; }
        [DataMember]
        public string TotalOrdersDealerBooked { get; set; }
        [DataMember]
        public string TotalOrdersCustomerBooked { get; set; }
    }
}
