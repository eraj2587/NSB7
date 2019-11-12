using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class DirectDebitTransactionInformation
    {
        [XmlElement("PmtId")]
        public PaymentIdentification PaymentInstructionId { get; set; }

        [XmlElement("PmtInf")]
        public PaymentInformation PaymentInformation { get; set; }

        [XmlElement("PmtTpInf")]
        public PaymentTypeInformation PaymentTypeInformation { get; set; }

        [XmlElement("InitgPty")]
        public PartyIdentification InitiatingParty { get; set; }

        [XmlElement("InstdAmt")]
        public CurrencyAndAmount CurrencyAndAmount { get; set; }

        [XmlElement("DrctDbtTx")]
        public DirectDebitTransaction DirectDebitTransaction { get; set; }

        [XmlElement("DbtrAgt")]
        public BranchAndFinancialInstitutionIdentification DebtorAgent { get; set; }

        [XmlElement("Dbtr")]
        public PartyIdentification Debtor { get; set; }

        [XmlElement("DbtrAcct")]
        public CashAccount DebtorAccount { get; set; }

        [XmlElement("RmtInf")]
        public RemittanceInformation RemittanceInformation { get; set; }
    }
}
