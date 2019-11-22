namespace NSB.Contracts.Services.DataContracts.Orders
{
    public enum OrderStatus : byte
    {
        Created = 0,
        Committed = 1,
        BookPending = 2,
        Booked = 3
    }

    public enum LineItemStatus
    {
        None = 0,
        Committed = 1,
        Booked = 2,
        Cancelled = 3,
        Repurchased = 4
    }

    public enum SettlementStatus : byte
    {
        None = 0,
        Committed = 1,
        Booked = 2,
        Cancelled = 3
    }

    public enum QuoteType
    {
        SystemConfiguredMarkup = 1,
        SpecifiedPercentageMarkup = 2,
        SpecifiedCustomerRate = 3,
        SpecifiedProfit = 4,
        OriginalCustomerRate = 5
    }

    public enum TradeDirection
    {
        NSBBuy = 1,
        NSBSell = 2
    }

    public enum FundingSourceType
    {
        Contract = 1,
        Quote = 2,
        Holding = 3
    }

    public enum Channel
    {
        None = 0,
        Email = 1,
        ScheduledPayment = 2,
        Phone = 3,
        PartnerWebService = 4,
        Cash = 5,
        Fax = 6,
        FileUpload = 7,
        MigrationTool = 8,
        DealerBooked = 9,
        CustomerBooked = 10,
        Adjustment = 11,
        Nexus = 12,
        MassPaymentService = 13
    }

    public enum NatureOfTransaction
    {
        Undefined = 0,
        Personal = 1,
        Business = 2
    }


    public enum FixedAmountType
    {
        Trade = 1,
        Settlement = 2
    }


    public enum RateDirection
    {
        Direct,
        Indirect
    }

    public enum PayeeType
    {
        Undefined = 0,
        Customer = 1,
        Beneficiary = 2
    }

    public enum Product
    {
        None = 0,
        Swap = 1,
        Forward = 2,
        FuturePayment = 3,
        Spot = 4,
        Ndf = 5
    }

    public enum CustomerRatePricingModel
    {
        Tiered = 1,
        Linear = 2,
        FixedSpread = 3
    }

    public enum SingleSideTransactionType
    {
        Unknown = 0,
        Pay = 1,
        Receive = 2
    }

    public enum OrderRateType 
    {
        Quote = 1,
        Fill = 2
    }

    public enum MarkupType
    {
        Percentage = 0,
        Pts = 1,
        Tenths = 2
    }

    public enum ClientTypeClassification
    {
       Internal = 422
    }

    public enum ClientArStatus
    {
        DeletedAccountByClient = 314,
        DeletedAccountByRuesch = 315,
        Freeze = 404
    }
}

