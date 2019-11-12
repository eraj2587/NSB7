namespace WUBS.Cct.DataExamples.Enums
{
    internal enum OrderType
    {
        NostroPayment = 1,
        ClientForwardSale = 5,
        ClientForwardSaleRepurchase = 11,
        LockIn = 12,
        LockInDisbursal = 13,
        LockInDisbursalRepurchase = 49,
        PaymentsNew = 103
    }

    internal enum ItemType
    {
        DraftPayment = 1,
        EftPayment = 2,
        IntoHolding = 3,
        ClientForwardSale = 14,
        LockIn = 55,
        LockInAdjustment = 66,
        EftPaymentRepurchase = 76,
        ClientForwardSaleRepurchase = 82,
        RepurchaseFee = 101,
        AchCredit = 212
    }

    internal enum PaymentFundedBy
    {
        Fx = 80,
        Holding = 81,
        Drawdown = 2017,
        Multiple = 2018
    }

    internal enum Application
    {
        GlobalPay = 2,
        GlobalPayPlus = 8,
        Nexus = 65
    }

    internal enum SettlementMethod
    {
        Undefined = 0,
        Wire = 61,
        EDebit = 62,
        Holding = 382,
        Drawdown = 1641
    }
}