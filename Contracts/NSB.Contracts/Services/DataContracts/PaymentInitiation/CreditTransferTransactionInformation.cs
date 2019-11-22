using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using NSB.Contracts.Services.DataContracts.Enums;

namespace NSB.Contracts.Services.DataContracts
{
    public class CreditTransferTransactionInformation
    {
        private string _paymentInfoId;

        [XmlElement("FwdgAgt")]
        public BranchAndFinancialInstitutionIdentification ForwardingAgent { get; set; }

        [XmlElement("InitgPty")]
        public PartyIdentification InitiatingParty { get; set; }

        [XmlElement("PmtInfId")]
        [MinLength(1), MaxLength(35)]
        public string PaymentInfoId
        {
            get { return _paymentInfoId; }
            set { _paymentInfoId = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("PmtMtd")]
        public PaymentMethodCode? PaymentMethod { get; set; }
        
        [XmlElement("ReqdExctnDt")]
        public string RequestedExecutionDateUtc { get; set; }

        [XmlElement("Dbtr")]
        public PartyIdentification Debtor { get; set; }

        [XmlElement("DbtrAcct")]
        public CashAccount DebtorAccount { get; set; }

        [XmlElement("DbtrAgt")]
        public BranchAndFinancialInstitutionIdentification DebtorAgent { get; set; }

        [XmlElement("ChrgBr")]
        public ChargeBearerTypeCode ChargeBearer { get; set; }

        [XmlElement("ChrgsAmt")]
        public Amount ChargeAmount { get; set; }

        [XmlElement("PmtId")]
        public PaymentIdentification PaymentInstructionId { get; set; }

        [XmlElement("PmtTpInf")]
        public PaymentTypeInformation PaymentTypeInformation { get; set; }
        
        [XmlElement("Amt")]
        public Amount Amount { get; set; }

        [XmlElement("IntrmyAgt1")]
        public BranchAndFinancialInstitutionIdentification IntermediaryBank { get; set; }

        [XmlElement("IntrmyAgt1Acct")]
        public CashAccount IntermediaryAgent1Account { get; set; }

        [XmlElement("CdtrAgt")]
        public BranchAndFinancialInstitutionIdentification BeneficiaryBank { get; set; }

        [XmlElement("Cdtr")]
        public PartyIdentification Beneficiary { get; set; }

        [XmlElement("CdtrAcct")]
        public CashAccount BeneficiaryAccount { get; set; }

        [XmlElement("InstrForCdtrAgt")]
        public InstructionForCreditorAgent InstructionForCreditorAgent { get; set; }

        [XmlElement("InstrForDbtrAgt")]
        public string InstructionForDebtorAgent { get; set; }
        [XmlElement("Purp")]
        public CategoryPurpose Purpose { get; set; }

        [XmlElement("RgltryRptg")]
        public RegulatoryReporting RegulatoryReporting { get; set; }
        
        [XmlElement("RmtInf")]
        public RemittanceInformation RemittanceInformation { get; set; }

        [XmlElement("ChrgBrTypFlag")]
        public string ChargeBearerTypeFlag { get; set; }

        [XmlElement("ReceiverBic")]
        [RegularExpression(@"[A-Z]{6,6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3,3}){0,1}")]
        public string ReceiverBic { get; set; }
    }
}
