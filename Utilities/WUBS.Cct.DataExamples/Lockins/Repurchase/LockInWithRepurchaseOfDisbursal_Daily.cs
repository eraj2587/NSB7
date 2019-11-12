using System;
using WUBS.Cct.DataExamples.Enums;
using WUBS.Cct.DataExamples.TestDataContainer;

namespace WUBS.Cct.DataExamples.Lockins.Repurchase
{
    public class LockInWithRepurchaseOfDisbursal_Daily : AbstractOrderData
    {
        private const string ConfirmationNumber = "LOCKINDISB123";
        private const string RepoConfirmationNumber = "LOCKINDISB123R1";
        public LockInWithRepurchaseOfDisbursal_Daily()
        {
            AddDatabase(new RueschlinkDB())
                .AddRow(new RueschlinkDB.ClientOrder.ClientOrderRow
                {
                    ClientOrder_ID = 1,
                    RelatedClientOrder_ID = 2,
                    ConfirmationNo = ConfirmationNumber,
                    Client_ID = 4,
                    RueschStaff_ID = 1335,
                    Application_ID = (int)Application.GlobalPayPlus,
                    User_ID = 58,
                    OrderType_ID = (int) OrderType.LockIn,
                    Ordered = DateTime.Now.Date,
                    SettlementCurrency_ID = CurrencyDefn.EUR.ID,
                    ItemTotal = 100,
                    NumberItems = 1
                })
                .AddRow(new RueschlinkDB.OrderDetail.OrderDetailRow
                {
                    ClientOrder_ID = 1,
                    OrderDetail_ID = 1,
                    ItemNo = 1,
                    ItemType_ID = (int)ItemType.LockIn,
                    Currency_ID = CurrencyDefn.AUD.ID,
                    CurrencyCode = CurrencyDefn.AUD.Code,
                    FundedBy = (int)PaymentFundedBy.Fx,
                    ForeignAmount = 148.81,
                    ForeignAmountIsInSC = 0,
                    ItemRate = 1.4881,
                    Quote_ID = 1,
                    Extension = 100,
                    Subtotal = 100,
                    ItemRateIsPer = 1,
                    ItemRate_NDec = 4,
                    RateMultiplier = 1,
                    Beneficiary_ID = 60222,
                    WindowLength = 0
                })
                .AddRow(new RueschlinkDB.ClientOrder.ClientOrderRow
                {
                    ClientOrder_ID = 2,
                    RelatedClientOrder_ID = 1,
                    ConfirmationNo = ConfirmationNumber,
                    Client_ID = 4,
                    RueschStaff_ID = 1335,
                    Application_ID = (int)Application.GlobalPayPlus,
                    User_ID = 58,
                    OrderType_ID = (int)OrderType.LockInDisbursal,
                    Ordered = DateTime.Now.Date,
                    SettlementCurrency_ID = CurrencyDefn.EUR.ID,
                    ItemTotal = 100,
                    NumberItems = 1
                })
                .AddRow(new RueschlinkDB.OrderDetail.OrderDetailRow
                {
                    ClientOrder_ID = 2,
                    OrderDetail_ID = 2,
                    ItemNo = 1,
                    ItemType_ID = (int)ItemType.EftPayment,
                    Currency_ID = CurrencyDefn.AUD.ID,
                    CurrencyCode = CurrencyDefn.AUD.Code,
                    FundedBy = (int)PaymentFundedBy.Fx,
                    ForeignAmount = 148.81,
                    ForeignAmountIsInSC = 0,
                    ItemRate = 1.4881,
                    Extension = 100,
                    Subtotal = 100,
                    ItemRateIsPer = 1,
                    ItemRate_NDec = 4,
                    RateMultiplier = 1,
                    Beneficiary_ID = 47,
                    WindowLength = 0
                })
                .AddRow(new RueschlinkDB.ClientOrder.ClientOrderRow
                {
                    ClientOrder_ID = 3,
                    RelatedClientOrder_ID = 1,
                    ConfirmationNo = RepoConfirmationNumber,
                    Client_ID = 4,
                    RueschStaff_ID = 1335,
                    Application_ID = (int)Application.GlobalPayPlus,
                    User_ID = 58,
                    OrderType_ID = (int)OrderType.LockInDisbursalRepurchase,
                    Ordered = DateTime.Now.Date,
                    SettlementCurrency_ID = CurrencyDefn.EUR.ID,
                    ItemTotal = 100,
                    NumberItems = 1
                })
                .AddRow(new RueschlinkDB.OrderDetail.OrderDetailRow
                {
                    ClientOrder_ID = 3,
                    OrderDetail_ID = 3,
                    RelatedOrderDetail_ID = 2,
                    ItemNo = 1,
                    ItemType_ID = (int)ItemType.EftPaymentRepurchase,
                    Currency_ID = CurrencyDefn.AUD.ID,
                    CurrencyCode = CurrencyDefn.AUD.Code,
                    FundedBy = (int)PaymentFundedBy.Fx,
                    ForeignAmount = 133.93,
                    ForeignAmountIsInSC = 1,
                    ItemRate = 1.4881,
                    Extension = 90,
                    Subtotal = 100,
                    ItemRateIsPer = 1,
                    ItemRate_NDec = 4,
                    RateMultiplier = 1,
                    Beneficiary_ID = 47,
                    WindowLength = 0
                });


            AddDatabase(new CrsDB())
                .AddRow(new CrsDB.Quote.QuoteRow
                {
                    Quote_ID = 1,
                    Currency_ID = CurrencyDefn.AUD.ID,
                    SettlementCurrency_ID = CurrencyDefn.EUR.ID,
                    Rate = 1.4881,
                    RateIsPer = 1,
                    SpotRate = 1.4653,
                    SpotRateIsPer = 1
                });

            AddDatabase(new VMSDB());
        }
    }
}
