using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class PartyChoice
    {
        [XmlElement("OrgId")]
        public OrganisationIdentification OrganisationIdentification { get; set; }

        [XmlElement("PrvtId")]
        public PersonIdentification PrivateIdentification { get; set; }
    }
}
