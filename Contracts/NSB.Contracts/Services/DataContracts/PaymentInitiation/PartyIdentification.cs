using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class PartyIdentification
    {
        private string _name;

        [XmlElement("Nm")]
        [MinLength(1), MaxLength(140)]
        public string Name
        {
            get { return _name; }
            set { _name = string.IsNullOrEmpty(value) ? null : value.Length > 140 ? value.Substring(0, 140) : value; }
        }

        [XmlElement("PstlAdr")]
        public PostalAddress PostalAddress { get; set; }

        [XmlElement("Id")]
        public PartyChoice Id { get; set; }

        [XmlElement("CtctDtls")]
        public ContactDetails ContactDetails { get; set; }
    }
}
