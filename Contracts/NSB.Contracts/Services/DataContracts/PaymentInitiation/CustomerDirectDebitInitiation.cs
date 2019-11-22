using System.Collections.Generic;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class CustomerDirectDebitInitiation
    {
        [XmlElement("GrpHdr")]
        public GroupHeader GroupHeader { get; set; }

        [XmlElement("DrctDbtTxInf")]
        public List<DirectDebitTransactionInformation> DirectDebitTransactionInformations { get; set; }
    }
}
