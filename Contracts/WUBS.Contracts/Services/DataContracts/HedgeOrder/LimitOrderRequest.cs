using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    [KnownType(typeof(NewLimitOrderRequest))]
    [KnownType(typeof(LimitOrderUpdateRequest))]
    public abstract class LimitOrderRequest
    {
    }

    [DataContract]
    public class NewLimitOrderRequest : LimitOrderRequest
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public TradeDirection TradeDirection { get; set; }
        [DataMember]
        public LimitOrderType OrderType { get; set; }
        [DataMember]
        public string TradeCurrency { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        [DataMember]
        public decimal TradeAmount { get; set; }
        [DataMember]
        public decimal SettlementAmount { get; set; }
        [DataMember]
        public string ExternalSystemReference { get; set; }
        [DataMember]
        public bool IsTradeAmountFixed { get; set; }
    }

    [DataContract]
    public class LimitOrderSearchRequest
    {
        [DataMember(Order = 0)]
        public string LimitOrderId { get; set; }
        [DataMember(Order = 1)]
        public string Account { get; set; }
        [DataMember(Order = 2)]
        public string CustomerName { get; set; }
        [DataMember(Order = 3)]
        public DateTimeOffset ExpiryDateTimeFrom { get; set; }
        [DataMember(Order = 4)]
        public DateTimeOffset ExpiryDateTimeTo { get; set; }
        [DataMember(Order = 5)]
        public List<LimitOrderStatusRequest> Status { get; set; }
        [DataMember(Order = 6)]
        public string SettlementCurrency { get; set; }
        [DataMember(Order = 7)]
        public string TargetCurrency { get; set; }
        [DataMember(Order = 8)]
        public LimitOrderProcessTypeRequest ProcessType { get; set; }
        [DataMember(Order = 9)]
        public string TargetAmount { get; set; }
        [DataMember(Order = 10)]
        public string Office { get; set; }
        [DataMember(Order = 11)]
        public LimitOrderTypeRequest OrderType { get; set; }
        [DataMember(Order = 12)]
        public LimitOrderSortColumn LimitOrderSort { get; set; }
        [DataMember(Order = 13)]
        public LimitOrderBySort LimitOrderSortBy { get; set; }
       [DataMember(Order = 14)]
        public DateTimeOffset? LastUpdatedFrom { get; set; }
        [DataMember(Order = 15)]
        public DateTimeOffset? LastUpdatedTo { get; set; }
        [DataMember(Order = 16)]
        public string CreatedBy { get; set; }
        [DataMember(Order = 17)]
        public string CurrencyPair { get; set; }
        [DataMember(Order = 18)]
        public string SupplierId { get; set; }
        [DataMember(Order = 19)]
        public long Page { get; set; }
        [DataMember(Order = 20)]
        public long PageSize { get; set; }
    }

    [DataContract]
    public class BuildAndSubmitLimitOrderRequest : NewLimitOrderRequest
    {
        [DataMember]
        public DateTimeOffset ExpiryDateTime { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public Channel Channel { get; set; }
        [DataMember]
        public bool IsDirectRate { get; set; }
        [DataMember]
        public decimal CustomerRate { get; set; }
        [DataMember]
        public decimal? DealerMargin { get; set; }
    }


    [DataContract]
    public class LimitOrderQuoteRequest : LimitOrderRequest
    {
        [DataMember]
        public string OrderId { get; set; }
    }

    [DataContract]
    public class LimitOrderCalculateRequest
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public decimal CustomerRate { get; set; }
        [DataMember]
        public bool IsDirect { get; set; }
        [DataMember]
        public decimal? DealerMargin { get; set; }

        [DataMember]
        public MarkupType MarkupType { get; set; }
    }

    [DataContract]
    public class LimitOrderCalculateWithDealerMargin
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public decimal CustomerRate { get; set; }
        [DataMember]
        public bool IsDirect { get; set; }
        [DataMember]
        public decimal? DealerMargin { get; set; }

        [DataMember]
        public MarkupType MarkupType { get; set; }
    }

    [DataContract]
    public class LimitOrderUpdateRequest : LimitOrderRequest
    {
        [DataMember]
        public string OrderId { get; set; }
    }

    [DataContract]
    public class LimitOrderSubmitRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public DateTimeOffset ExpiryDateTime { get; set; }
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderApproveRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderRejectRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderCancelRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderApproveCancelRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderRejectCancelRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class ChangeTypeRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderModifyRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public DateTimeOffset ExpiryDateTime { get; set; }
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderModifyTreasuryRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public decimal? TreasuryAdjustment { get; set; }
        [DataMember]
        public string SupplierName { get; set; }
        [DataMember]
        public string Note { get; set; }

    }

    [DataContract]
    public class LimitOrderFillRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }

        //[DataMember]
        //public decimal TriggerRate { get; set; }

        //[DataMember]
        //public string SupplierName { get; set; }

    }

    [DataContract]
    public class LimitOrderRefreshQueryRequest
    {
        [DataMember]
        public DateTimeOffset RefreshDate { get; set; }
        [DataMember]
        public LimitOrderStatus[] Statuses { get; set; }

    }

    [DataContract]
    public class LimitOrderApproveExpiryRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
    }

    [DataContract]
    public class LimitOrderRejectExpiryRequest : LimitOrderUpdateRequest
    {
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public DateTimeOffset ExpiryDateTime { get; set; }
    }

    [DataContract]
    public class LimitOrderSearchRefreshRequest
    {
        [DataMember]
        public DateTimeOffset PreviousDateTime { get; set; }
    }

    [DataContract]
    public class LimitOrderHistoryReportRequest
    {
        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public string ClientId { get; set; }

        [DataMember]
        public string ClientName { get; set; }
    }

    [DataContract]
    public class LimitOrderStatisticsReportRequest
    {
        [DataMember(Order = 0)]
        public DateTimeOffset FromDateTime { get; set; }
        [DataMember(Order = 1)]
        public DateTimeOffset ToDateTime { get; set; }
        [DataMember(Order = 2)]
        public string Office { get; set; }
    }
}
