using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class CategoryPurpose
    {
        private string _cd;
        private string _proprietary;

        [XmlElement("Cd")]
        [MinLength(1), MaxLength(4)]
        public string Cd
        {
            get { return _cd; }
            set { _cd = string.IsNullOrEmpty(value) ? null : value.Length > 4 ? value.Substring(0, 4) : value; }
        }

        [XmlElement("Prtry")]
        [MinLength(1), MaxLength(35)]
        public string Proprietary
        {
            get { return _proprietary; }
            set { _proprietary = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }
    }
}
