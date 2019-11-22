using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class PersonIdentification
    {
        [XmlElement("Othr")]
        public GenericFinancialIdentification GenericPersonIdentification { get; set; }
    }
}
