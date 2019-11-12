using System.Xml.Serialization;
using WUBS.Contracts.Services.DataContracts.Enums;

namespace WUBS.Contracts.Services.DataContracts
{
    public class RegulatoryReporting
    {
        [XmlElement("DbtCdtRptgInd")]
        public DebitCreditReportingIndicator Indicator { get; set; }

        [XmlElement("Authrty")]
        public RegulatoryAuthority RegulatoryAuthority { get; set; }

        [XmlElement("Dtls")]
        public StructuredRegulatoryReporting StructuredRegulatoryReporting { get; set; }
    }
}
