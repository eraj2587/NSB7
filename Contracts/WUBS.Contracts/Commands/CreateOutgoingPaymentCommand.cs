using System;
using System.Collections.Generic;
using WUBS.Contracts.Events;
using WUBS.Contracts.Models;
using WUBS.Contracts.Services.DataContracts;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.Payments")]
    public class CreateOutgoingPaymentCommand
    {
        public long Id { get; set; }
        public string PublicId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Creator { get; set; }
        public byte EntityType { get; set; }
        public long PaymentId { get; set; }
        public long? SourceId { get; set; }
        public byte? SourceType { get; set; }
        public byte ResultedFromOperation { get; set; }
        public string OrderId { get; set; }
        public string ExternalOrderReference { get; set; }
        public byte Status { get; set; }
        public byte InstructionStatus { get; set; }
        public bool IsOnHold { get; set; }
        public bool? IsDoddFrank { get; set; }
        public byte OneSideType { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string FeeCurrency { get; set; }
        public decimal? FeeAmount { get; set; }
        public byte PaymentMethodId { get; set; }
        public string NotionalCurrency { get; set; }
        public decimal? NotionalAmount { get; set; }
        public string SettlementCurrency { get; set; }

        //public decimal? SettlementAmount { get; set; } //Commented as right now we are considering only payment mordernization
        public string SettlementAmountNdec { get; set; }
        public DateTimeOffset BookingDateTime { get; set; }
        public DateTime ValueDate { get; set; }
        public bool IsTreasurySetValueDate { get; set; }
        public DateTime? ExpectedReleaseDate { get; set; }
        public DateTimeOffset? ActualReleaseDateTime { get; set; }
        public DateTime? ExpectedPayeeReceiveDate { get; set; }
        public DateTime? ChequeDate { get; set; }
        [Encrypt]
        public string ChequeNumber { get; set; }
        public byte? AuthorizationOptions { get; set; }
        [Encrypt]
        public string Payer { get; set; }
        [Encrypt]
        public string PayerName { get; set; }
        [Encrypt]
        public string Payee { get; set; }
        [Encrypt]
        public string PayeeAccount { get; set; }
        [Encrypt]
        public string PayeeName { get; set; }
        public int? PayeeProcessingCenterID { get; set; }
        public string Contact { get; set; }
        public string ThirdPartyInstructor { get; set; }
        [Encrypt]
        public string Customer { get; set; }
        [Encrypt]
        public string PayerBankAccount { get; set; }
        [Encrypt]
        public string PayeeBankAccount { get; set; }
        public string Reference { get; set; }
        public string CRMCaseID { get; set; }
        public string ExternalSystemReference { get; set; }
        public string Comment { get; set; }
        public string ReasonForPayment { get; set; }
        public decimal? ExpectedBeneficiaryTaxes { get; set; }
        public byte? FinancialAllocationCharge { get; set; }
        public DateTimeOffset? LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public string AuthorizedBy { get; set; }
        public long PaymentInstructionId { get; set; }
        [Encrypt]
        public string Body { get; set; }
        public string Type { get; set; }
        public string StatusMessage { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastUpdatedOn { get; set; }
        public string SwiftUETR { get; set; }
        public int CctStatusId { get; set; }
        public int ItemTypeId { get; set; }
        public string OriginalPaymentId { get; set; }
        public string OriginalOrderId { get; set; }
        public decimal? Rate { get; set; }
        public int? RateNdec { get; set; }
        public decimal? ServiceCharges { get; set; }
        public decimal? GrandTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public DateTime? AchievableValueDate { get; set; }
        //public string SettlementMethodDescription { get; set; } // as a part of payment Modernization commenting code
        //public string OrderEnteredBy { get; set; } //Commented as right now we are considering only payment mordernization
        public DateTime? ClearDate { get; set; }
        public DateTime? PaymentInitiatedDate { get; set; }
        public bool IsAutoRelease { get; set; }
        //PYT- 3177
        public int? OpsessAccountId { get; set; }
        public string BenefeciaryBankCountry { get; set; }
        public string ItemType { get; set; }
        public DateTime? ActualValueDate { get; set; }
        public DateTime? GmtDeadline { get; set; }
        public string ConfirmationNo { get; set; }
        public int ItemNo { get; set; }      
        public List<Hold> Holds { get; set; }
        public DateTime? DisclosureDate { get; set; }
        public DateTime? ConsumerPaymentAvailableDate { get; set; }
        [Encrypt]
        public string DebitBankDescription { get; set; }
        [Encrypt]
        public string DebitBankSwiftAddress { get; set; }
        [Encrypt]
        public string DebitBankAccountNumber { get; set; }
        [Encrypt]
        public string DebitBankAccountOwnerName { get; set; }
        public string AmountNDec { get; set; }
        public PaymentCustomerDetails CustomerDetails { get; set; }
        public bool IsCustomerMultiParty { get; set; }
        public int? NostroBankAccountChannelId { get; set; }

        public DateTimeOffset? AchievablePaymentValueDate { get; set; }
    }
}
