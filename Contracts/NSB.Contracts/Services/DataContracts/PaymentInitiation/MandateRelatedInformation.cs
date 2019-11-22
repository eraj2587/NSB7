using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class MandateRelatedInformation
    {
        private string _mandateId;

        [XmlElement("MndtId")]
        [MinLength(1), MaxLength(35)]
        public string MandateId
        {
            get { return _mandateId; }
            set { _mandateId = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("DtOfSgntr")]
        public string DateOfSigning { get; set; }

        [XmlElement("AmdmntInd")]
        public bool AmendmentIndicator { get; set; }

        [XmlElement("AmdmntInfDtls")]
        public AmendmentInformationDetails AmendmentInformationDetails { get; set; }
    }
}
