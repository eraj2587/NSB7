using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class BranchIdentification
    {
        private string _id;
        private string _name;

        [XmlElement("Id")]
        [MinLength(1), MaxLength(35)]
        public string Id
        {
            get { return _id; }
            set { _id = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("Nm")]
        [MinLength(1), MaxLength(140)]
        public string Name
        {
            get { return _name; }
            set { _name = string.IsNullOrEmpty(value) ? null : value.Length > 140 ? value.Substring(0, 140) : value; }
        }

        [XmlElement("PstlAdr")]
        public PostalAddress PostalAddress { get; set; }
    }
}
