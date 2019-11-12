using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class PersonIdentification
    {
        [XmlElement("Othr")]
        public GenericFinancialIdentification GenericPersonIdentification { get; set; }
    }
}
