using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class CompliancePayment
    {
        [DataMember]
        [JsonProperty(PropertyName = "sourcePaymentID")]
        public int SourcePaymentId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "platform")]
        public string PaymentPlatform { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "bookingSystemOrderID")]
        public string BookingSystemOrderId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "bookingSystemName")]
        public string BookingSystemName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "orderID")]
        public int OrderId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "feeAmount")]
        public decimal FeeAmount { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "feeCurrency")]
        public string FeeCurrency { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime PaymentCreationDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "creationDateUTC")]
        public DateTimeOffset PaymentCreationDateUtc { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "orderTypeName")]
        public string OrderTypeName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "itemTypeName")]
        public string ItemTypeName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lineItemID")]
        public int LineItemId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "confirmationNumber")]
        public string ConfirmationNumber { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime PaymentLastUpdated { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lastUpdatedUTC")]
        public DateTimeOffset PaymentLastUpdatedUtc { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "method")]
        public string PaymentMethod { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "reasonForTransaction")]
        public string PaymentReasonForTransaction { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "orderReasonForTransaction")]
        public string OrderReasonForTransaction { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "receiverInformationText")]
        public string ReceiverInformationText { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "expectedValueDate")]
        public DateTime? ExpectedValueDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "deadlineDate")]
        public DateTime? DeadlineDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "isDoddFrank")]
        public int IsDoddFrank { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "notifiedPerson")]
        public NotifiedPerson NotifiedPerson { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "byOrderOf")]
        public string ByOrderOf { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "BIC")]
        public string Bic { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "yourID")]
        public string YourId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "WUReceiver")]
        public ReceiverInformation WuReceiver { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lineItemNo")]
        public int LineItemNo { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "settlementCurrency")]
        public string SettlementCurrency { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "buySell")]
        public string BuySell { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "isOutgoing")]
        public int IsOutgoing { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "branchID")]
        public int BranchId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "delivery")]
        public ComplianceDelivery Delivery { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "recipient")]
        public ComplianceCategory Recipient { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "sender")]
        public ComplianceCategory Sender { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "thirdPartyRemitter")]
        public ComplianceCategory ThirdPartyRemitter { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "thirdPartyInstructorID")]
        public string ThirdPartyInstructorId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "beneficiaryRemitter")]
        public ComplianceCategory BeneficiaryRemitter { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "authorizedUser")]
        public ComplianceCategory AuthorizedUser { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "customerID")]
        public int CustomerId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "senderBankAccountID")]
        public string SenderBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "recipientBankAccountID")]
        public string RecipientBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "remitterBankAccountID")]
        public string RemitterBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "intermediaryBankAccountID")]
        public string IntermediaryBankAccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "parties")]
        public List<ComplianceParty> ComplianceParties { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "bankDetails")]
        public List<ComplianceBankAccount> ComplianceBankAccounts { get; set; }
    }

    [DataContract]
    public class ComplianceEntity
    {
        [DataMember]
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "account")]
        public string Account { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "countryName")]
        public string CountryName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "mobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "alternateName")]
        public string AlternateName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "alternateShipToName")]
        public string AlternateShipToName { get; set; }
    }

    [DataContract]
    public class ComplianceCategory
    {
        [DataMember]
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }
    }

    [DataContract]
    public class ComplianceAddress
    {
        [DataMember]
        [JsonProperty(PropertyName = "line1")]
        public string AddressLine1 { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "line2")]
        public string AddressLine2 { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "line3")]
        public string AddressLine3 { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "stateOrProvinceCode")]
        public string StateOrProvinceCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "stateOrProvinceName")]
        public string StateOrProvinceName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "countryName")]
        public string CountryName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "compositeAddr")]
        public string AddressField { get; set; }
    }

    [DataContract]
    public class ComplianceDelivery
    {
        [DataMember]
        [JsonProperty(PropertyName = "ID")]
        public int Id { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "address")]
        public ComplianceAddress Address { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "statusName")]
        public string StatusName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime? CreationDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime? LastUpdated { get; set; }
    }

    [DataContract]
    public class ComplianceContact
    {
        [DataMember]
        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "additionalPhone")]
        public string AdditionalPhone { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "additionalFax")]
        public string AdditionalFax { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "additionalEmail")]
        public string AdditionalEmail { get; set; }
    }

    [DataContract]
    public class ComplianceIndividual
    {
        [DataMember]
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "dateOfBirth")]
        public string DateofBirth { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "citizenshipCountryCode")]
        public string CitizenshipCountryCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationCode")]
        public string IdentificationCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationIssuer")]
        public string IdentificationIssuer { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationIssuerCountry")]
        public string IdentificationIssuerCountry { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationTypeName")]
        public string IdentificationTypeName { get; set; }
    }

    [DataContract]
    public class ComplianceCompany
    {
        [DataMember]
        [JsonProperty(PropertyName = "industryType")]
        public string IndustryType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "legalName")]
        public string LegalName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "tradeName")]
        public string TradeName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "customerBusinessType")]
        public string CustomerBusinessType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "incorporationState")]
        public string IncorporationState { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "customerCategory")]
        public string CustomerCategory { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "LEI")]
        public string LEI { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "DUNSNumber")]
        public string DUNSNumber { get; set; }
    }

    [DataContract]
    public class ComplianceMiscellaneous
    {
        [DataMember]
        [JsonProperty(PropertyName = "accountCode")]
        public string AccountCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "accountNo")]
        public string AccountNo { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "individualFlag")]
        public int IndividualFlag { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "isSWB")]
        public int IsSWB { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "branchCode")]
        public string BranchCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "branchType")]
        public string BranchType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "salesforceAMLRiskRating")]
        public string SalesforceAMLRiskRating { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "complianceCustomerTypeKey")]
        public string ComplianceCustomerTypeKey { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "complianceIndustryTypeKey")]
        public string ComplianceIndustryTypeKey { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "owningLegalEntityName")]
        public string OwningLegalEntityName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "retailAuthorizedUser")]
        public int IsRetailAuthorizedUser { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "thirdPartyInstructor")]
        public string IsThirdPartyInstructor { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "beneficiaryRemitter")]
        public string IsBeneficiaryRemitter { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "sourcePlatformID")]
        public int SourcePlatformId { get; set; }
    }
}
