using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class BranchAndFinancialInstitutionIdentification
    {
        [XmlElement("FinInstnId")]
        public FinancialInstitutionIdentification FinancialInstitutionIdentification  { get; set; }

        [XmlElement("BrnchId")]
        public BranchIdentification BranchIdentification { get; set; }
    }
}
