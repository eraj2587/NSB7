using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class OrganisationIdentification
    {
        [XmlElement("Othr")]
        public GenericOrganisationIdentification GenericOrganisationIdentification;
    }
}
