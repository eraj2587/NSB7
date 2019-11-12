using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class GroupHeader
    {
        [XmlElement("MsgId")]
        public string MsgId { get; set; }
        
        [XmlElement("CreDtTm")]
        public string CreatedOnUtcString { get; set; }

        [XmlElement("NbOfTxs")]
        public int PaymentCount { get; set; }

        [XmlElement("CtrlSum")]
        public string TotalAmount { get; set; }

        public string FileBody { get; set; }

        [XmlElement("FwdgAgt")]
        public BranchAndFinancialInstitutionIdentification ForwardingAgent { get; set; }
    }
}
