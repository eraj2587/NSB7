using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class OrganisationIdentification
    {
        [XmlElement("Othr")]
        public GenericOrganisationIdentification GenericOrganisationIdentification;
    }
}
