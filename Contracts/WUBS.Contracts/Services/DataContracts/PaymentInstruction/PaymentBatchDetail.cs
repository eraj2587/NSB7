using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class PaymentBatchDetail
    {
        [DataMember]
        public Guid TempId { get; set; }
        [DataMember]
        public long PaymentBatchDetailId { get; set; }
        [DataMember]
        public long PaymentBatchId { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string StatusMessage { get; set; }
        [DataMember]
        public DateTimeOffset CreatedOn { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdatedOn { get; set; }

        //Class Memebers
        [DataMember]
        public string PaymentStatus { get; set; }
        [DataMember]
        public int PainFileFormat { get; set; }
        [DataMember]
        public string ErrorCode { get; set; }
        [DataMember]
        public int WubsBankAccountOwnerId { get; set; }
        [DataMember]
        [NameFormat]
        public string WubsBankAccountOwnerName { get; set; }
        [DataMember]
        public string WubsBankAccountOwnerShortName { get; set; }
        [DataMember]
	  	[PostalAddressFormat]
        public string WubsBankAccountAddressLine { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string WubsBankAccountCity { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string WubsBankAccountProvinceState { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string WubsBankAccountPostalCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string WubsBankAccountCountry { get; set; }
        [DataMember]
        [AccountNumberFormat]
        public string WubsBankAccountNumber { get; set; }
        [DataMember]
        [SwiftAddressFormat]
        public string WubsBankAccountReceiverBic { get; set; }
        [DataMember]
        [NameFormat]
        public string ByOrderOf { get; set; }
        [DataMember]
        public int PaymentInfoId { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }
        [DataMember]
        public DateTime RequestedExecutionDate { get; set; }
        [DataMember]
        [NameFormat]
        public string PayerName { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerAddressLine { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerCity { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerProvinceState { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerPostalCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerCountry { get; set; }
        [DataMember]
        [DebtorAccountFormat]
        public string PayerAccountNumber { get; set; }
        [DataMember]
        [NameFormat]
        public string PayerAccountName { get; set; }
        [DataMember]
        public string PayerBankBic { get; set; }
        [DataMember]
        [AccountNumberFormat]
        public string PayerRoutingCode2 { get; set; }
        [DataMember]
        [NameFormat]
        public string PayerBranchName { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerBankPostalCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerBankCity { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerBankProvinceState { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerBankCountry { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayerBankAddressLine { get; set; }
        [DataMember]
        public string PayerUniqueMandateReference { get; set; }
        [DataMember]
        public DateTime PayerDateOfSigning { get; set; }
        [DataMember]
        public string PayerIdentityCode { get; set; }
        [DataMember]
        [AccountNumberFormat]
        public string PayerReferenceNumber { get; set; }
        [DataMember]
        [SwiftAddressFormat]
        public string ThirdPartyBIC { get; set; }
        [DataMember]
        [NameFormat]
        public string ThirdPartyName { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string ThirdPartyCity { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string ThirdPartyState { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string ThirdPartyCountry { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string ThirdPartyAddress { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string ThirdPartyProvince { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string ThirdPartyPostalCode { get; set; }
        [DataMember]
        [AccountNumberFormat]
        public string ThirdPartyAccount { get; set; }
        [DataMember]
        [NameFormat]
        public string DebitBranchName { get; set; }
        [DataMember]
        public string ScBearer { get; set; }
        [DataMember]
        public decimal ChargeAmount { get; set; }
        [DataMember]
        public string CreditCurrencyCode { get; set; }
        [DataMember]
        public string OutGoingConfirmation { get; set; } 
        [DataMember]
        public int EndToEndId { get; set; }
        [DataMember]
        public string ServiceLevelProprietary { get; set; } 
        [DataMember]
        public string ClearingTypeCode { get; set; } 
        [DataMember]
        public decimal CreditAmount { get; set; }
        [DataMember]
        public string NDec { get; set; }
        [DataMember]
        [SwiftAddressFormat]
        public string IntermediaryBankBic { get; set; }
        [DataMember]
        [AccountNumberFormat]
        public string IntermediaryBankRoutingCode2 { get; set; }
        [DataMember]
        [NameFormat]
        public string IntermediaryBankBranchName { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string IntermediaryBankPostalCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string IntermediaryBankCity { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string IntermediaryBankProvinceState { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string IntermediaryBankCountryCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string IntermediaryBankAddressLine { get; set; }
        [DataMember]
        [NameFormat]
        public string IntermediaryBankName { get; set; }
        [DataMember]
        [AccountNumberFormat]
        public string IntermediaryBankAccountNumber { get; set; }
        [DataMember]
        [SwiftAddressFormat]
        public string PayeeBankBic { get; set; }
        [DataMember]
        [CreditAccountNumberFormat]
        public string PayeeBankAccountNumber { get; set; }
        [DataMember]
		[AccountNumberFormat]
        public string PayeeRoutingCode2 { get; set; }
        [DataMember]
        [NameFormat]
        public string PayeeBankName { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeBankPostalCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeBankCity { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeBankProvinceState { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeBankCountryCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeBankAddressLine { get; set; }
        [DataMember]
        [NameFormat]
        public string PayeeBranchName { get; set; }
        [DataMember]
        [NameFormat]
        public string PayeeName { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeePostalCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeCity { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeProvinceState { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeCountryCode { get; set; }
        [DataMember]
        [PostalAddressFormat]
        public string PayeeAddressLine { get; set; }
        [DataMember]
        [AccountNumberFormat]
        public string PayeeAccountNumber { get; set; }
        [DataMember]
        public string PayeeAccountType { get; set; }
        [DataMember]
        [NameFormat]
        public string PayeeAccountName { get; set; }
        [DataMember]
        [NameFormat]
        public string PayeeContactName { get; set; }
        [DataMember]
        public string PayeeEmailAddress { get; set; }
        [DataMember]
        [PhoneNumberFormat]
        public string PayeePhoneNumber { get; set; }
        [DataMember]
        public int InstructionCodeForBank { get; set; } 
        [DataMember]
        [AlphaNumericFormat]
        public string InstructionInformation { get; set; } 
        [DataMember]
        [AlphaNumericFormat]
        public string ReasonForPayment { get; set; } 
        [DataMember]
        [AlphaNumericFormat]
        public string PurposeOfPayment { get; set; }
        [DataMember]
        public string PurposeOfPaymentId { get; set; } 
        [DataMember]
        public int IsGTYOUREnabled { get; set; }
        [DataMember]
        public int IsAutoconvert { get; set; }
        [DataMember]
        public bool IsIAT { get; set; }
        [DataMember]
        public string IncomingConfirmation { get; set; }
        [DataMember]
        public decimal DebitAmount { get; set; }
        [DataMember]
        public string DebitCurrencyCode { get; set; }
        [DataMember]
        public DateTime RequestedCollectionDate { get; set; }
        [DataMember]
        public string SepaScheme { get; set; }
        [DataMember]
        public string SepaCreditorIdentifier { get; set; }
        [DataMember]
        public string PaymentCode { get; set; }
        [DataMember]
        public string SepaItemDebitRum { get; set; }
        [DataMember]
        public string SepaItemDebitBic { get; set; }
        [DataMember]
        public string SepaItemDebitIban { get; set; }
        [DataMember]
        public string SepaItemCreditorIdentifier { get; set; }
        [DataMember]
        public string SepaItemCreditorLegalEntityName { get; set; }
        [DataMember]
        public string SepaItemDebtorAgent { get; set; }
        [DataMember]
        public bool SepaItemAmendmentIndicator { get; set; }
        [DataMember]
        public DateTime SepaItemFirstDueDate { get; set; }
        [DataMember]
        public string CheckNumber { get; set; }
        [DataMember]
        public string ReceiversCorrespondentAccountNumber { get; set; }
        [DataMember]
        public string ReceiversCorrespondentSwiftAddress { get; set; }
        [DataMember]
        [SwiftUETRFormat]
        public string SwiftUETR { get; set; }
        /// <summary>
        /// 1 - Draft
        /// 2 - Check
        /// </summary>
        [DataMember]
        public int DraftType { get; set; }
        [DataMember]
        public int SourceId { get; set; }
        [DataMember]
        public int ChargeBearer { get; set; }
        [DataMember]
        public int ReleaseType { get; set; }
        [DataMember]
        public bool ArStatus { get; set; }
    }
}
