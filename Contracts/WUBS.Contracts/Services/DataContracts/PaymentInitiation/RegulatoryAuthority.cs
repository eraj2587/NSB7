using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class RegulatoryAuthority
    {
        private string _name;

        [XmlElement("Nm")]
        [MinLength(1), MaxLength(140)]
        public string Name
        {
            get { return _name; }
            set { _name = string.IsNullOrEmpty(value) ? null : value.Length > 140 ? value.Substring(0, 140) : value; }
        }

        [XmlElement("Ctry")]
        [RegularExpression(@"[A-Z]{2,2}")]
        public string Country { get; set; }
    }
}
