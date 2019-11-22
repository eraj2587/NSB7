using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class DirectDebitTransaction
    {
        [XmlElement("MndtRltdInf")]
        public MandateRelatedInformation MandateRelatedInformation { get; set; }
    }
}
