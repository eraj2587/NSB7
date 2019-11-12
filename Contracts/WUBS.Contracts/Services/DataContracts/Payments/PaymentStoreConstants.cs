namespace WUBS.Contracts.Services.DataContracts.Payments
{
    public class PaymentStoreConstants
    {
        public const string InvalidPayments = "invalidpayments";
        public const string RejectedPayments = "rejectedpayments";
        public const string NoSalesforcecaseInvalidPayments = "nosalesforcecaseinvalidpayments";
        public const string NoSalesforcecaseRejectedPayments = "nosalesforcecaserejectedpayments";
        public const string HoldOfacPayments = "holdofacpayments";
        public const string OfacStatusInProcess = "ofacstatusinprocess";
        public const string OfacStatusComplianceHold = "ofacstatuscompliancehold";
        public const string OfacStatusComplianceCancel = "ofacstatuscompliancecancel";
        public const string OfacStatusComplianceBlocked = "ofacstatuscomplianceblocked";
        public const string PaymentFileStatusAccp = "ACCP";
        public const string PaymentFileStatusAccpept = "ACCEPT";
        public const string PaymentFileStatusRjct = "RJCT";
        public const string PaymentFileStatusReject = "REJECT";
        public const string PaymentFileAccepted = "ACCP";
        public const string PaymentFileRejected = "RJCT";
        public const string TestSearchPayments = "testsearchpayments";
        public const string MaxPageSizeCnfKey = "MaxPageSize";
        public const string ReleaseDateRangeCnfKey = "ReleaseDateRange";
        public const string ValueDateRangeCnfKey = "ValueDateRange";
        public const int OtherholdOnPaymentErrorCode = 1401;
        public const string OtherholdOnPaymentErrorMsg = "Cannot create case, Active hold other present on Payment";
        public const int PaymentIdNotFoundErrorCode = 1402;
        public const string PaymentIdNotFoundErrorMsg = "Payment doesn't exists in system";
        public const int CaseDetailsSucessfullySavedCode = 1403;
        public const string CaseDetailsSucessfullySavedMsg = "Case got created successfully";
        public const string PaymentStore = "PaymentStore";
        public const string HoldReasonForMannualCaseHoldOther = "Hold other";
        public const string SearchPaymentsSp = "SearchPayments";
        public const string SearchPaymentsByExactMatchSp = "SearchPaymentsByExactMatch";
        public const string OpsUiEditClaimsKey = "sf_opsui_authorizer_edit";
        public const string OpsUiEditClaim = "OPSUIAccess";
    }
}
