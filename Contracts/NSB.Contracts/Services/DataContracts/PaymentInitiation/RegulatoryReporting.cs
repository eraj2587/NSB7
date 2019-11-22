using System.Xml.Serialization;
using NSB.Contracts.Services.DataContracts.Enums;

namespace NSB.Contracts.Services.DataContracts
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
