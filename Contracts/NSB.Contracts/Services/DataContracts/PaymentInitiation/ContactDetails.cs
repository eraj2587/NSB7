using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class ContactDetails
    {
        private string _name;
        private string _emailAddress;

        [XmlElement("Nm")]
        [MinLength(1), MaxLength(140)]
        public string Name
        {
            get { return _name; }
            set { _name = string.IsNullOrEmpty(value) ? null : value.Length > 140 ? value.Substring(0, 140) : value; }
        }

        [XmlElement("PhneNb")]
        [RegularExpression(@"\+[0-9]{1,3}-[0-9()+\-]{1,30}")]
        public string PhoneNumber { get; set; }

        [XmlElement("EmailAdr")]
        [MinLength(1), MaxLength(2048)]
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = string.IsNullOrEmpty(value) ? null : value.Length > 2048 ? value.Substring(0, 2048) : value; }
        }
    }
}
