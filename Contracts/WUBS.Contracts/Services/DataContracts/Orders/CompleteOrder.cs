using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts
{

    [DataContract]
    public class CompleteOrder
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string UserId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string ContactId { get; set; }
        [DataMember]
        public string OfficeId { get; set; }
        [DataMember]
        public string CustomerReferenceNumber { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }
        [DataMember]
        public Channel Channel { get; set; }
        [DataMember]
        public Platform Platform { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public TradeDirection Direction { get; set; }
        [DataMember]
        public OrderStatus Status { get; set; }
        [DataMember]
        public DateTimeOffset OrderCreatedOn { get; set; }
        [DataMember]
        public DateTimeOffset? ExpiryTimestamp { get; set; }
        [DataMember]
        public CompleteLineItem[] LineItems { get; set; }
        [DataMember]
        public CompleteOrderSettlement[] Settlements { get; set; }
        [DataMember]
        public Fee[] Fees { get; set; }
        [DataMember]
        public CompleteOrderQuote[] Quotes { get; set; }
        [DataMember]
        public string ExternalSystem { get; set; }
        [DataMember]
        public string BookingSource { get; set; }
        [DataMember]
        public string BookedBy { get; set; }
        [DataMember]
        public DateTimeOffset? BookingDateTime { get; set; }

    }

    [DataContract]
    public class CompleteOrderQuote
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Money Settlement { get; set; }
        [DataMember]
        public Money Trade { get; set; }
        [DataMember]
        public Rate Rate { get; set; }
        [DataMember]
        public Rate InvertedRate { get; set; }
        [DataMember]
        public Rate CostRate { get; set; }
        [DataMember]
        public DateTimeOffset ExpiryDate { get; set; }
        [DataMember]
        public DateTimeOffset IssuedAt { get; set; }
        [DataMember]
        public QuoteType QuoteType { get; set; }
        [DataMember]
        public Rate MarketSpotRate { get; set; }
        [DataMember]
        public Rate ReportingCurrencyToUsdRate { get; set; }
        [DataMember]
        public Rate SettlementCurrencyToUsdRate { get; set; }
        [DataMember]
        public Currency ReportingCurrency { get; set; }
        [DataMember]
        public Rate SettlementToReportingRate { get; set; }
        [DataMember]
        public Rate InvertedCostRate { get; set; }
        [DataMember]
        public decimal CustomerMarkup { get; set; }
        [DataMember]
        public decimal CustomerForwardPoints { get; set; }
        [DataMember]
        public CustomerRatePricingModel CustomerRatePricingModel { get; set; }
        [DataMember]
        public decimal MarketForwardPoints { get; set; }
        [DataMember]
        public decimal CostSpread { get; set; }
        [DataMember]
        public DateTime CostRateCalculatedOn { get; set; }
        [DataMember]
        public Rate TradeCurrencyToUsdRate { get; set; }
        [DataMember]
        public Rate TradeToReportingRate { get; set; }
    }

    [DataContract]
    public class CompleteOrderSettlement
    {
        [DataMember]
        public int SettlementId { get; set; }
        [DataMember]
        public SettlementMethod SettlementMethod { get; set; }
        [DataMember]
        public Money Settlement { get; set; }
        [DataMember]
        public SettlementStatus Status { get; set; }
        [DataMember]
        public string CustomerReference { get; set; }
        [DataMember]
        public Money EstimatedProfit { get; set; }
    }


    [DataContract]
    public class CompleteLineItem
    {
        [DataMember]
        public int LineItemId { get; set; }
        [DataMember]
        public PaymentMethod PaymentMethod { get; set; }
        [DataMember]
        public string PayeeId { get; set; }
        [DataMember]
        public PayeeType PayeeType { get; set; }
        [DataMember]
        public decimal OriginalAmount { get; set; }
        [DataMember]
        public Money Trade { get; set; }
        [DataMember]
        public Money Settlement { get; set; }
        [DataMember]
        public FixedAmountType FixedAmountType { get; set; }
        [DataMember]
        public Rate Rate { get; set; }
        [DataMember]
        public Rate InvertedRate { get; set; }
        [DataMember]
        public Rate CostRate { get; set; }
        [DataMember]
        public Rate InvertedCostRate { get; set; }
        [DataMember]
        public Rate SettlementToUsdRate { get; set; }
        [DataMember]
        public Rate SettlementToReportingRate { get; set; }
        [DataMember]
        public Currency ReportingCurrency { get; set; }
        [DataMember]
        public string CustomerReference { get; set; }
        [DataMember]
        public DateTime TradeValueDate { get; set; }
        [DataMember]
        public NatureOfTransaction NatureOfTransaction { get; set; }
        [DataMember]
        public ReasonForTransaction ReasonForTransaction { get; set; }
        [DataMember]
        public string ReasonForTransactionText { get; set; }
        [DataMember]
        public string ExternalReference { get; set; }
        [DataMember]
        public FundingSource[] FundingSources { get; set; }
        [DataMember]
        public LineItemStatus Status { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public Money WubsProfit { get; set; }
        [DataMember]
        public string BankAccount { get; set; }
        [DataMember]
        public Rate TradeToUsdRate { get; set; }
        [DataMember]
        public Rate TradeToReportingRate { get; set; }
        [DataMember]
        public Currency PayeeDefaultCurrency { get; set; }
    }

    [DataContract]
    public class FundingSource
    {
        [DataMember]
        public int QuoteId { get; set; }
        [DataMember]
        public string ContractId { get; set; }
        [DataMember]
        public DateTime ValueDate { get; set; }
    }
}