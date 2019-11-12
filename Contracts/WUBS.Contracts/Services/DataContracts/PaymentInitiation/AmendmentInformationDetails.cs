using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class AmendmentInformationDetails
    {
        private string _originalMandateId;

        [XmlElement("OrgnlMndtId")]
        [MinLength(1), MaxLength(35)]
        public string OriginalMandateId
        {
            get { return _originalMandateId; }
            set { _originalMandateId = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("OrgnlCdtrSchmeId")]
        public PartyIdentification OriginalCreditorSchemeId { get; set; }

        [XmlElement("OrgnlDbtrAcct")]
        public CashAccount OriginalDebtorAccount { get; set; }

        [XmlElement("OrgnlDbtrAgt")]
        public BranchAndFinancialInstitutionIdentification OriginalDebtorAgent { get; set; }
    }
}
