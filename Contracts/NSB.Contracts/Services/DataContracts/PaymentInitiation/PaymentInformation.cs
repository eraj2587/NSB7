using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using NSB.Contracts.Services.DataContracts.Enums;

namespace NSB.Contracts.Services.DataContracts
{
    public class PaymentInformation
    {
        private string _paymentInfoId;

        [XmlElement("PmtInfId")]
        [MinLength(1), MaxLength(35)]
        public string PaymentInfoId
        {
            get { return _paymentInfoId; }
            set { _paymentInfoId = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }
        
        [XmlElement("PmtMtd")]
        public PaymentMethodCode? PaymentMethod { get; set; }

        [XmlElement("NbOfTxs")]
        public int PaymentCount { get; set; }

        [XmlElement("CtrlSum")]
        public string TotalAmount { get; set; }

        [XmlElement("ReqdColltnDt")]
        public string RequestedCollectionDateUtc { get; set; }
        
        [XmlElement("Cdtr")]
        public PartyIdentification Creditor { get; set; }
        
        [XmlElement("CdtrAcct")]
        public CashAccount CreditorAccount { get; set; }

        [XmlElement("CdtrAgt")]
        public BranchAndFinancialInstitutionIdentification CreditorBank { get; set; }

        [XmlElement("ChrgBr")]
        public string ChargeBearer { get; set; }

        [XmlElement("CdtrSchmeId")]
        public PartyIdentification CreditorScheme { get; set; }
    }
}
