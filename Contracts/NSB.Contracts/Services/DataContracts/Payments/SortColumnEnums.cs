using System.ComponentModel;

namespace NSB.Contracts.Services.DataContracts.Payments
{
    public enum SearchPaymentsRequestSortColumnEnum
    {
        [Description("transactionreference")]
        TransactionReference = 0,
        [Description("paymentmethod")]
        PaymentMethod = 1,
        [Description("paymentstatus")]
        PaymentStatus = 2,
        [Description("releasedate")]
        ReleaseDate = 3,
        [Description("valuedate")]
        ValueDate = 4,
        [Description("gmtdeadline")]
        GmtDeadline = 5,
        [Description("hold")]
        Hold = 6,
        [Description("cctstatus")]
        CctStatus = 7
    }
}
