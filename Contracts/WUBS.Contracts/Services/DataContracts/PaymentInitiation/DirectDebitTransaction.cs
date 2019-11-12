using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class DirectDebitTransaction
    {
        [XmlElement("MndtRltdInf")]
        public MandateRelatedInformation MandateRelatedInformation { get; set; }
    }
}
