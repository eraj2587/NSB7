using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using WUBS.Contracts.Models;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    [KnownType(typeof(IncomingPayment))]
    [KnownType(typeof(OutgoingPayment))]
    public abstract class Payment
    {
        [DataMember]
        public string PaymentId { get; set; }

        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }

        [DataMember]
        public string Creator { get; set; }

        [DataMember]
        public long SourceId { get; set; }

        [DataMember]
        public PaymentSourceType? SourceType { get; set; }

        [DataMember]
        public string OrderId { get; set; }

        [DataMember]
        public PaymentMethod PaymentMethodId { get; set; }
        [DataMember]
        public OneSideType OneSideType { get; set; }

        [DataMember]
        public Money Amount { get; set; }

        [DataMember]
        public Money FeeAmount { get; set; }

        [DataMember]
        public Money NotionalAmount { get; set; }

        [DataMember]
        public DateTimeOffset BookingDateTime { get; set; }

        [DataMember]
        public DateTime ValueDate { get; set; }

        [DataMember]
        public DateTimeOffset? LastUpdatedAt { get; set; }

        [DataMember]
        public string LastUpdatedBy { get; set; }

        [DataMember]
        public string Payer { get; set; }
        [DataMember]
        public string PayerName { get; set; }

        [DataMember]
        public string Payee { get; set; }

        [DataMember]
        public string Customer { get; set; }

        [DataMember]
        public string PayerBankAccount { get; set; }

        [DataMember]
        public string PayeeBankAccount { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string ThirdPartyInstructor { get; set; }

        [DataMember]
        public string Contact { get; set; }

        [DataMember]
        public string AuthorizedBy { get; set; }

        [DataMember]
        public Currency SettlementCurrency { get; set; }

        [DataMember]
        public ResultedFromOperation ResultedFromOperation { get; set; }

        [DataMember]
        public AuthorizationOptions AuthorizationOptions { get; set; }

        [DataMember]
        public string ExternalOrderReference { get; set; }

        [DataMember]
        public string ExternalSystemReference { get; set; }

        [DataMember]
        public int ItemTypeId { get; set; }

        [DataMember]
        public Customer CustomerDetails { get; set; }
    }

    [DataContract]
    public class IncomingPayment : Payment
    {
        [DataMember]
        public DateTime? ExpectedClearingDate { get; set; }

        [DataMember]
        public DateTimeOffset? ActualClearingDate { get; set; }

        [DataMember]
        public DateTime? ExpectedReceiveDate { get; set; }

        [DataMember]
        public DateTimeOffset? ActualReceiveDateTime { get; set; }

        [DataMember]
        public string OriginCountryCode { get; set; }

        [DataMember]
        public string ThirdPartyRemitter { get; set; }

        [DataMember]
        public IncomingPaymentStatus Status { get; set; }

        [DataMember]
        public string PayerAccount { get; set; }

        [DataMember]
        public int PayerProcessCenterId { get; set; }
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
    }

    [DataContract]
    public class OutgoingPayment : Payment
    {
        [DataMember]
        public bool OnHold { get; set; }

        [DataMember]
        public DateTime? ExpectedReleaseDate { get; set; }

        [DataMember]
        public DateTimeOffset? ActualReleaseDateTime { get; set; }

        [DataMember]
        public DateTime? ExpectedPayeeReceiveDate { get; set; }

        [DataMember]
        public decimal? ExpectedBeneficiaryTaxes { get; set; }

        [DataMember]
        public string ReasonForPayment { get; set; }

        [DataMember]
        public DateTime? ChequeDate { get; set; }

        [DataMember]
        public bool IsDoddFrank { get; set; }

        [DataMember]
        public OutgoingPaymentStatus Status { get; set; }

        [DataMember]
        public string PayeeAccount { get; set; }

        [DataMember]
        public string PayeeName { get; set; }

        [DataMember]
        public int? PayeeProcessingCenterId { get; set; }

        [DataMember]
        public FinancialAllocationCharge FinancialAllocationCharge { get; set; }

        [DataMember]
        public Rate TradeToUsdRate { get; set; }
        [DataMember]
        public Rate TradeToReportingRate { get; set; }

        [DataMember]
        public string OriginalPaymentId { get; set; }

        [DataMember]
        public string OriginalOrderId { get; set; }

        [DataMember]
        public decimal? Rate { get; set; }

        public int? RateNDec { get; set; }

        [DataMember]
        public decimal? ServiceCharges { get; set; }

        [DataMember]
        public decimal? GrandTotal { get; set; }

        [DataMember]
        public decimal? SubTotal { get; set; }

        [DataMember]
        public DateTime? AchievableValueDate { get; set; }

        //[DataMember]
        //public string SettlementMethodDescription { get; set; }// as a part of payment Modernization commenting code

        //[DataMember]
        //public string OrderEnteredBy { get; set; } //Commented as right now we are considering only payment mordernization

        //[DataMember]
        //public decimal? SettlementAmount { get; set; } //Commented as right now we are considering only payment mordernization

        [DataMember]
        public string SettlementAmountNdec { get; set; }

        [DataMember]
        public DateTime? ClearDate { get; set; }

        [DataMember]
        public DateTime? PaymentInitiatedDateTime { get; set; }

        //PYT-3177
        [DataMember]
        public int OpsessAccountId { get; set; }

        [DataMember]
        public string BenefeciaryBankCountry { get; set; }

        [DataMember]
        public string ItemType { get; set; }

        [DataMember]
        public string ActualValueDate { get; set; }
        //API-1301
        [DataMember]
        public DateTime? GmtDeadline { get; set; }
        [DataMember]
        public string ConfirmationNo { get; set; }
        [DataMember]
        public int ItemNo { get; set; }
        [DataMember]
        public DateTime? DisclosureDt { get; set; }
        [DataMember]
        public DateTime? ConsumerPaymentAvailableDt { get; set; }

        [DataMember]
        public DateTimeOffset? AchievablePaymentValueDate { get; set; }

    }

    [DataContract]
    public class PaymentExceptionResponse
    {
        [DataMember]
        public List<PaymentException> PaymentExceptionList { get; set; }
        [DataMember]
        public int TotalRecords { get; set; }
    }

    [DataContract]
    public class BeneficiaryDetailsResponse
    {
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string BeneficiaryFamiliarName { get; set; }
        [DataMember]
        public Address BeneficiaryAddress { get; set; }
        [DataMember]
        public string BeneficiaryAccountNumber { get; set; }
        [DataMember]
        public string BeneficiaryType { get; set; }
        [DataMember]
        public string BeneficiaryTelephoneNumber { get; set; }
        [DataMember]
        public string BeneficiaryContactName { get; set; }
        [DataMember]
        public string BeneficiaryEmailAddress { get; set; }
        [DataMember]
        public string PurposeofPayment { get; set; }
        [DataMember]
        public string CustomerReference { get; set; }
        [DataMember]
        public string SWIFTBranchDetails { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public Address BankAddress { get; set; }
        [DataMember]
        public string BankSWIFT { get; set; }
        [DataMember]
        public string RoutingCode { get; set; }
        [DataMember]
        public string IBKName { get; set; }
        [DataMember]
        public Address IBKAddress { get; set; }
        [DataMember]
        public string IBKSWIFT { get; set; }
        [DataMember]
        public string IBKRoutingCode { get; set; }
        [DataMember]
        public bool BeneficiaryNotficationEnabled { get; set; }
        [DataMember]
        public string PublicId { get; set; }
        [DataMember]
        public string CustomerVendorId { get; set; }
    }

    [DataContract]
    public class PaymentClientDetailResponse
    {
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public string Office { get; set; }
        [DataMember]
        public string OfficeCode { get; set; }
        [DataMember]
        public string CustomerAccountNumber { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public ClientAddress CustomerAddress { get; set; }
        [DataMember]
        public string ProcessingCenter { get; set; }
        [DataMember]
        public string ProcessingCenterCode { get; set; }
        [DataMember]
        public string TypeClassification { get; set; }
        [DataMember]
        public string TypeClassificationCode { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string CategoryCode { get; set; }
        [DataMember]
        public string RemitterAccountNumber { get; set; }
        [DataMember]
        public string RemitterName { get; set; }
        [DataMember]
        public ClientAddress RemitterAddress { get; set; }
        [DataMember]
        public string RemitterFIAccountNumber { get; set; }
        [DataMember]
        public string RemitterFIName { get; set; }
        [DataMember]
        public ClientAddress RemitterFIAddress { get; set; }
        [DataMember]
        public string RemitterFISwiftBIC { get; set; }
        [DataMember]
        public string PublicId { get; set; }
    }



    [DataContract]
    public class PaymentException
    {
        [DataMember]
        public string WubsPublicId { get; set; }
        [DataMember]
        public string PaymentReference { get; set; }
        [DataMember]
        public string WubsPaymentStatus { get; set; }
        [DataMember]
        public string ItemType { get; set; }

        //[DataMember]
        //public string Body { get; set; }
        [DataMember]
        public byte PaymentDirection { get; set; }
        [DataMember]
        public string InventoryCode { get; set; }
        [DataMember]
        public DateTimeOffset? ActualValueDate { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }
        [DataMember]
        public string NumberOfDecimals { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string CustomertId { get; set; }
        [DataMember]
        public OutgoingPaymentStatus ReleasedPaymentStatus { get; set; }
        [DataMember]
        public string ErrorReason { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public bool? DoddFrankPayment { get; set; }
        [DataMember]
        public bool? CaseOpened { get; set; }
        [DataMember]
        public string WubsBankName { get; set; }

    }


    [DataContract]
    public class PaymentGeneralDetailsResponse
    {
        [DataMember]
        public string TransactionReference { get; set; }
        [DataMember]
        public string PaymentBatchedReference { get; set; }
        [DataMember]
        public string ItemType { get; set; }
        [DataMember]
        public string ChargeType { get; set; }
        [DataMember]
        public string InventoryCode { get; set; }
        [DataMember]
        public string CheckNumber { get; set; }
        [DataMember]
        public string PaymentFileStatus { get; set; }
        [DataMember]
        public string PaymentFileFormat { get; set; }
        [DataMember]
        public string PaymentFileBody { get; set; }
        [DataMember]
        public string SourceSystem { get; set; }
        [DataMember]
        public string GpgFileId { get; set; }
        [DataMember]
        public string Uetr { get; set; }
        // As per Alex email: The WUBS2 Payment ID can be changed to the Original Payment ID
        [DataMember]
        public string PublicId { get; set; }
        [DataMember]
        public int OrderDetailId { get; set; }
        [DataMember]
        public MoneyDto Amount { get; set; }
        [DataMember]
        public DebitBankDto NostroBankDetails { get; set; }
        //TODO: This needs to be confirmed which status to pick payment, instruction or batch status
        [DataMember]
        public string PaymentStatus { get; set; }
        /// <summary>
        /// Present in PaymentInstruction table column as StatusMessage and under PaymentBatchReturnFileDetail table column as Additional Info
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public string PaymentWarning { get; set; }
        [DataMember]
        public DateTime? ValueDate { get; set; }
        [DataMember]
        public DateTime RequestedValueDate { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }
        [DataMember]
        public DateTime? ArPaymentRecieved { get; set; }
        [DataMember]
        public string PaidAndPostedInAr { get; set; }
        [DataMember]
        public bool? IsConsumerPayment { get; set; }
        [DataMember]
        public DateTime DoddFrankDisclosureDate { get; set; }
        [DataMember]
        public DateTime DoddFrankAvailableDate { get; set; }
        /// <summary>
        /// TODO: Need to find
        /// Assuming : BookingDateTime in PaymentTable is the correct field
        /// </summary>
        [DataMember] //Removing the comment for API-1832 
        public DateTime OrderDate { get; set; }
        //Not sure where this data resides
        //[DataMember]
        //public DateTime OrderCompletedDate { get; set; } //Commented as a part of payment Mordernization
        /// <summary>
        /// TODO: Need to determine
        /// Assuming: ActualReleaseDateTime in OutGoingPayment table is the correct field
        /// </summary>
        [DataMember]
        public DateTime ReleasedDate { get; set; }

        [DataMember]
        public string OriginalPaymentId { get; set; }

        [DataMember]
        public string OriginalOrderId { get; set; }

        [DataMember]
        public long? PaymentBatchDetailId { get; set; }

        [DataMember]
        public long? PaymentBatchId { get; set; }

        [DataMember]
        public bool? GuranteedOur { get; set; }

        [DataMember]
        public string TimeUntilPaymentReleased { get; set; }

        [DataMember]
        public PercentageAmountDto Rate { get; set; }

        [DataMember]
        public MoneyDto SubTotal { get; set; }

        [DataMember]
        public MoneyDto ServiceFee { get; set; }

        [DataMember]
        public MoneyDto Taxes { get; set; }

        [DataMember]
        public MoneyDto ItemTotal { get; set; }


        [DataMember]
        public List<PaymentCaseDetails> SfCaseNumberOfInvalidRejected { get; set; }

        [DataMember]
        public List<PaymentCaseDetails> SfCasesNumber { get; set; }

        [DataMember]
        public bool? AutoConvert { get; set; }

        [DataMember]
        public bool IsIat { get; set; }

        [DataMember]
        public DateTimeOffset? AchievableValueDate { get; set; }

        [DataMember]
        public string IncomingOrderReference { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
        //public SettlementDetailDto SettlementDetail { get; set; } //Commented as a part of payment modernization

        //[DataMember] as part of payemnet mordenization Commented 
        //public string EnteredBy { get; set; }

        [DataMember]
        public DateTimeOffset? PaymentInitiatedDateTime { get; set; }

        [DataMember]
        public string CustomerAccountNumber { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public DateTime? ClearDate { get; set; }
        [DataMember]
        public List<PaymentHold> Holds { get; set; }
        [DataMember]
        public string NostroAccountCode { get; set; }
        [DataMember]
        public string AchType { get; set; }

    }
    [DataContract]
    public class PaymentGeneralDetails : PaymentGeneralDetailsResponse
    {
        [DataMember]
        public string NostroAccountID { get; set; }
    }

    [DataContract]
    public class MoneyDto
    {
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string NumberOfDecimals { get; set; }
        [DataMember]
        public string CurrencyCode { get; set; }
    }

    [DataContract]
    public class PercentageAmountDto
    {
        [DataMember]
        public decimal? Amount { get; set; }
        [DataMember]
        public int? NumberOfDecimals { get; set; }

    }

    //Commented as a part of payment Mordernization
    //public class SettlementDetailDto 
    //{
    //    //public decimal? SettlementAmount { get; set; }
    //    //public string SettlementMethod { get; set; }
    //    public string SettlementCurrencyCode { get; set; }
    //    //public int? SettlementAmountNDec { get; set; }
    //}
    [DataContract]
    public class DebitBankDto
    {
        [DataMember]
        public string AccountNumber { get; set; }
        [DataMember]
        public string AccountEntity { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string BankSwift { get; set; }
    }


    [DataContract]
    public class PaymentExceptionSearchRequest
    {

        [DataMember]
        //Filter Parameters
        public String PaymentReferceneNumber { get; set; }
        [DataMember]
        public long Page { get; set; }
        [DataMember]
        public long PageSize { get; set; }
        [DataMember]
        public DateTimeOffset? FromReleaseDate { get; set; }
        [DataMember]
        public DateTimeOffset? ToReleaseDate { get; set; }
        [DataMember]
        public string CustomerId { get; set; }

    }

    [DataContract]
    public class PaymentStoreRequest
    {

        [DataMember]
        public string TransactionReference { get; set; }
        [DataMember]
        public string OriginalOrderId { get; set; }
        [DataMember]
        public string OriginalPaymentId { get; set; }
        [DataMember]
        public string CheckNumber { get; set; }
        [DataMember]
        public int[] PaymentMethodId { get; set; }
        [DataMember]
        public int? Status { get; set; }
        [DataMember]
        public long page { get; set; }
        [DataMember]
        public long pagesize { get; set; }
        [DataMember]
        public DateTimeOffset? FromReleaseDate { get; set; }
        [DataMember]
        public DateTimeOffset? ToReleaseDate { get; set; }
        [DataMember]
        public DateTime? FromValueDate { get; set; }
        [DataMember]
        public DateTime? ToValueDate { get; set; }
        [DataMember]
        public string SortBy { get; set; }
        [DataMember]
        public string SortOrder { get; set; }
        [DataMember]
        public string Filter { get; set; }

    }

    [DataContract]
    public class PaymentStoreResponse
    {
        [DataMember]
        public List<PaymentStore> PaymentStoreList { get; set; }
        [DataMember]
        public long TotalSearchResults { get; set; }
        [DataMember]
        public long page { get; set; }
        [DataMember]
        public long pageSize { get; set; }
        [DataMember]
        public string Filter { get; set; }


    }

    [DataContract]
    public class PaymentStore
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }
        [DataMember]
        public DebitBankDto PayoutBankDetails { get; set; }
        [DataMember]
        public string ActualValueDate { get; set; }
        [DataMember]
        public DateTime? GmtDeadline { get; set; }
        [DataMember]
        public string TransactionReference { get; set; }
        [DataMember]
        public MoneyDto Amount { get; set; }
        [DataMember]
        public string CustomerAccountNumber { get; set; }
        [DataMember]
        public bool? OnHold { get; set; }
        [DataMember]
        public string PaymentStatus { get; set; }
        [DataMember]
        public string PublicId { get; set; }
        [DataMember]
        public string FileStatus { get; set; }
        [DataMember]
        public string SfCase { get; set; }
        [DataMember]
        public string PaymentWarning { get; set; }
        [DataMember]
        public string InventoryCode { get; set; }
        [DataMember]
        public string NostroAccountCode { get; set; }
        [DataMember]
        public List<PaymentHold> Holds { get; set; }
        [DataMember]
        public int? OutgoingPaymentId { get; set; }
    }

    [DataContract]
    public class PaymentHold
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public bool? Status { get; set; }
        [DataMember]
        public string HoldReason { get; set; }
    }

    [DataContract]
    public class PaymentEntityType
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public byte EntityType { get; set; }
    }

    [DataContract]
    public class PaymentActiveHolds
    {
        [DataMember]
        public string HoldType { get; set; }
        [DataMember]
        public int? HoldTypeId { get; set; }
        [DataMember]
        public int? PaymentStatus { get; set; }
        [DataMember]
        public int PaymentId { get; set; }
        [DataMember]
        public string PaymentStatusDescription { get; set; }
    }

    [DataContract]
    public class PaymentsCount
    {
        //[DataMember]
        //public int Id { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public string Filter { get; set; }
    }


    [DataContract]
    public class PaymentDetail
    {

        [DataMember]
        public string ClientID { get; set; }
        [DataMember]
        public string PaymentID { get; set; }
        [DataMember]
        public string SourceSystem { get; set; }
        [DataMember]
        public string PaymentWarning { get; set; }
        // [DataMember] public string ItemType { get; set; }
        [DataMember]
        public string TransactionCurrency { get; set; }
        [DataMember]
        public string TransactionAmount { get; set; }
        [DataMember]
        public string TransactionNumberOfDecimals { get; set; }
        [DataMember]
        public string TransactionReference { get; set; }
        [DataMember]
        public string BeneficiaryName { get; set; }
        [DataMember]
        public string BeneficiaryBankCountry { get; set; }
        [DataMember]
        public string ConsumerPayment { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public string BatchID { get; set; }
        [DataMember]
        public string PaymentInstructionStatus { get; set; }
        [DataMember]
        public string FileBatchStatus { get; set; }
        [DataMember]
        public string PaymentConfirmationNumber { get; set; }
        [DataMember]
        public string LineItemNumber { get; set; }
        [DataMember]
        public string OrderDate { get; set; }
        [DataMember]
        public string ActualValueDate { get; set; }
        [DataMember]
        public string PaymentPurpose { get; set; }
        [DataMember]
        public string ClientReferenceNumber { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }
        [DataMember]
        public int OutgoingPaymentId { get; set; }
        [DataMember]
        public string OriginalPaymentId { get; set; }
        [DataMember]
        public string OriginalOrderId { get; set; }
        [DataMember]
        public string DoddFrankAvailableDate { get; set; }
        [DataMember]
        public string DraftNumber { get; set; }
        [DataMember]
        public string SettlementCurrency { get; set; }
    }

    [DataContract]
    public class PaymentCaseRequest
    {
        [DataMember]
        public string PublicId { get; set; }
        [DataMember]
        public string ClientID { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public string CaseStatus { get; set; }
        [DataMember]
        public string CaseFailureReason { get; set; }
        [DataMember]
        public string UserId { get; set; }
    }

    [DataContract]
    public class PaymentCaseResponse
    {
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Message { get; set; }
    }

    [DataContract]
    public enum OneSideType : byte
    {
        [EnumMember]
        Undefined = 0,
        [EnumMember]
        TrustFund = 1,
        [EnumMember]
        ForwardDeposit = 2,
        [EnumMember]
        Charge = 3,
    }


    [DataContract]
    public enum SettlementMethod
    {
        [EnumMember]
        Unknown = -1,
        [EnumMember]
        None = 0,
        [EnumMember]
        Wire = 1,
        [EnumMember]
        Draft = 2,
        [EnumMember]
        Cheque = 3,
        [EnumMember]
        EFT = 4,
        //[EnumMember]
        //Transfer = 5,
        [EnumMember]
        Cash = 6,
        [EnumMember]
        DirectDebit = 7,
        //[EnumMember]
        //TrustFund = 8,
        //[EnumMember]
        //ForwardDeposit = 9,
        [EnumMember]
        //Email = 10,
        //[EnumMember]
        BillPay = 11,
        [EnumMember]
        Holding = 12
    }

    [DataContract]
    public enum PaymentMethod : byte
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        Wire = 1,
        [EnumMember]
        Draft = 2,
        [EnumMember]
        Cheque = 3,
        [EnumMember]
        EFT = 4,
        //[EnumMember]
        //Transfer = 5,
        [EnumMember]
        Cash = 6,
        [EnumMember]
        DirectDebit = 7,
        //[EnumMember]
        //TrustFund = 8,
        //[EnumMember]
        //ForwardDeposit = 9,
        //[EnumMember]
        //Email = 10,
        //[EnumMember]
        //BillPay = 11,
        [EnumMember]
        Holding = 12,
        [EnumMember]
        Sweep = 13,
        [EnumMember]
        SweepNostroToOps = 14,
        [EnumMember]
        SweepOpsToNostro = 15,
        [EnumMember]
        FxCounterpartySettlement = 16,
        [EnumMember]
        DraftToBene = 17,
        [EnumMember]
        RealTimeDraft = 18,
        [EnumMember]
        ACH = 19,
        [EnumMember]
        RepurchasePayoutWireRelease = 20
    }

    [DataContract]
    public enum ResultedFromOperation : byte
    {
        [EnumMember]
        Undefined = 0,
        [EnumMember]
        Regular = 1,
        [EnumMember]
        Repurchase = 2
    }

    [DataContract]
    public enum AuthorizationOptions : byte
    {
        [EnumMember]
        Undefined = 0,
        [EnumMember]
        CanBeAuthorized = 1,
        [EnumMember]
        Pending = 2
    }

    public enum CaseType : byte
    {
        [EnumMember]
        None = 0,
        [EnumMember]
        AutoCase = 1,
        [EnumMember]
        ManualCase = 2
    }

    [DataContract]
    public enum FinancialAllocationCharge
    {
        [EnumMember]
        Undefined = 0,
        [EnumMember]
        Both = 1,
        [EnumMember]
        SenderPays = 2,
        [EnumMember]
        ReceiverPays = 3
    }

    [DataContract]
    public class PaymentCaseDetailsResponse
    {
        [DataMember]
        public string PaymentId { get; set; }
        [DataMember]
        public string SfCaseNumber { get; set; }
        [DataMember]
        public string PaymentFailureReason { get; set; }

    }

    [DataContract]
    public class PaymentCaseDetails
    {
        [DataMember]
        public string SfCaseNumber { get; set; }
    }

    [DataContract]
    public class PaymentCaseDto
    {
        public string SfCaseNumber { get; set; }
        public string PublicId { get; set; }
        public string PaymentFailureReason { get; set; }
        public string SfCaseStatus { get; set; }
        public string SfCaseFailureReason { get; set; }
        public int? CaseType { get; set; }
    }

    public class PaymentGeneralDetailsDto
    {
        public string PaymentId { get; set; }
        public string OriginalPaymentId { get; set; }
        public DateTime AchievableValueDate { get; set; }
        public string ConfirmationNo { get; set; }
        public int? ItemNo { get; set; }
        public string OriginalOrderId { get; set; }
        public float? ServiceCharges { get; set; }
        public float? GrandTotal { get; set; }
        public string SettlementAmountNdec { get; set; }
        public float? SubTotal { get; set; }
        public float? Rate { get; set; }
        public string ClientName { get; set; }
        public string ClientAccountNumber { get; set; }
        public int? RateNdec { get; set; }
        public DateTime? ValueDate { get; set; }
        public string SettlementCurrency { get; set; }
        public DateTime? ClearDate { get; set; }
        public DateTime? PaymentInitiatedDateTime { get; set; }
        public DateTime? RequestedValueDate { get; set; }
        public bool? IsConsumerPayment { get; set; }
        public DateTime? DisclosureDate { get; set; }
        public DateTime? ConsumerPaymentAvailableDate { get; set; }
        public int? PaymentFileFormat { get; set; }
        public long? PaymentBatchId { get; set; }
        public int? FileStatus { get; set; }
        public string PaymentBatchBody { get; set; }
        public int? PaymentBatchDetailId { get; set; }
        public string PaymentBatchDetailsBody { get; set; }
        public string PaymentFileWarning { get; set; }
        public string ErrorCode { get; set; }
        public string PaymentFileStatus { get; set; }
        public int? PaymentInstructionStatus { get; set; }
        public string PaymentInstructionWarning { get; set; }
        public string Body { get; set; }
        public string Uetr { get; set; }
        public string PaymentMethodDescription { get; set; }
        public string ItemType { get; set; }
        public string PaymentTypeCode { get; set; }
        public DateTime OrderDate { get; set; }
    }

    [DataContract]
    public class PaymentCustomerDetails
    {
        [DataMember]
        [Encrypt]
        public string Account { get; set; }
        [DataMember]
        public string Id { get; set; }
        [Encrypt]
        [DataMember]
        public string Client { get; set; }
        [DataMember]
        public PaymentCustomerAddress Address { get; set; }
        [DataMember]
        public Office Office { get; set; }
        [DataMember]
        public ProcessCenter ProcessCenter { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public TypeClassification TypeClassification { get; set; }
        [DataMember]
        public Category Category { get; set; }
    }

    [DataContract]
    public class PaymentCustomerAddress
    {
        [DataMember]
        [Encrypt]
        public string StreetAddress1 { get; set; }

        [DataMember]
        [Encrypt]
        public string StreetAddress2 { get; set; }

        [DataMember]
        public string StreetAddress3 { get; set; }

        [DataMember]
        [Encrypt]
        public string City { get; set; }

        [DataMember]
        [Encrypt]
        public string State { get; set; }

        [DataMember]
        [Encrypt]
        public string Province { get; set; }
        [DataMember]
        [Encrypt]
        public string ZipPostalCode { get; set; }

        [DataMember]
        public Country Country { get; set; }
    }

    [DataContract]
    public class TypeClassification
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    [DataContract]
    public class Category
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}