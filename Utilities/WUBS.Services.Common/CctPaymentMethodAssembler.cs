using System;
using WUBS.Contracts.Services.DataContracts;
using WUBS.ResourceAccess.CCTOrderRA.Contracts.Data;

namespace WUBS.Services.Common
{
    public static class CctPaymentMethodAssembler
    {
        public static SettlementMethod ToSettlementMethod(int paymentMethodId)
        {
            SettlementMethod settlementMethod;

            var paymentMethod = Enum.IsDefined(typeof(CctPaymentMethod), paymentMethodId) ? (CctPaymentMethod)paymentMethodId : CctPaymentMethod.Unknown;

            switch (paymentMethod)
            {
                case CctPaymentMethod.Edebit:
                case CctPaymentMethod.DrawDown:
                    settlementMethod = SettlementMethod.DirectDebit;
                    break;
                default:
                    settlementMethod = SettlementMethod.None;
                    break;
            }

            return settlementMethod;
        }

        public static PaymentMethod ToPaymentMethod(int itemTypeId)
        {
            PaymentMethod paymentMethod;

            var itemType = Enum.IsDefined(typeof(CctItemType), itemTypeId) ? (CctItemType)itemTypeId : CctItemType.None;

            switch (itemType)
            {
                case CctItemType.FTSweep:
                    paymentMethod = PaymentMethod.Sweep;
                    break;
                case CctItemType.FTSweepNostroToOps:
                    paymentMethod = PaymentMethod.SweepNostroToOps;
                    break;
                case CctItemType.FTSweepOpsToNostro:
                    paymentMethod = PaymentMethod.SweepOpsToNostro;
                    break;
                case CctItemType.ACHCredit:
                    paymentMethod = PaymentMethod.ACH;
                    break;
                case CctItemType.EFT:
                case CctItemType.FTCollateral:
                    paymentMethod = PaymentMethod.Wire;
                    break;
                case CctItemType.Draft:
                    paymentMethod = PaymentMethod.Draft;
                    break;
                case CctItemType.Holding:
                    paymentMethod = PaymentMethod.Holding;
                    break;
                case CctItemType.FTVendorPayment:
                    paymentMethod = PaymentMethod.FxCounterpartySettlement;
                    break;
                case CctItemType.Draft2Bene:
                    paymentMethod = PaymentMethod.DraftToBene;
                    break;
                case CctItemType.RtDraft:
                    paymentMethod = PaymentMethod.RealTimeDraft;
                    break;
                case CctItemType.RepurchPayoutEFTRel:
                    paymentMethod = PaymentMethod.RepurchasePayoutWireRelease;
                    break;
                default:
                    paymentMethod = PaymentMethod.None;
                    break;
            }

            return paymentMethod;
        }

        public static string ToPaymentMethodByClearingType(int clearingTypeId)
        {
            string paymentMethod;

            var clearingType = Enum.IsDefined(typeof(ClearingType), clearingTypeId)
                ? (ClearingType)clearingTypeId
                : ClearingType.None;

            switch (clearingType)
            {
                case ClearingType.LowValue:
                    paymentMethod = "ACH";
                    break;
                case ClearingType.HighValue:
                    paymentMethod = "Wire";
                    break;
                default:
                    paymentMethod = "NONE";
                    break;
            }
            return paymentMethod;
        }

        public static Func<Payment, bool> IsElectronicPayment =
            (payment) =>
            {
                return payment.PaymentMethodId == PaymentMethod.Wire ||
                       payment.PaymentMethodId == PaymentMethod.Sweep ||
                       payment.PaymentMethodId == PaymentMethod.SweepNostroToOps ||
                       payment.PaymentMethodId == PaymentMethod.SweepOpsToNostro ||
                       payment.PaymentMethodId == PaymentMethod.FxCounterpartySettlement ||
                       payment.PaymentMethodId == PaymentMethod.ACH ||
                       payment.PaymentMethodId == PaymentMethod.RepurchasePayoutWireRelease;
            };

        public static Func<Payment, bool> IsCheckPayment =
            (payment) =>
            {
                return payment.PaymentMethodId == PaymentMethod.Draft || 
                payment.PaymentMethodId == PaymentMethod.DraftToBene || 
                payment.PaymentMethodId == PaymentMethod.RealTimeDraft;
            };

        public static Func<Payment, bool> IsHoldingPayment =
           (payment) =>
           {
               return payment.PaymentMethodId == PaymentMethod.Holding;
           };
    }
}
