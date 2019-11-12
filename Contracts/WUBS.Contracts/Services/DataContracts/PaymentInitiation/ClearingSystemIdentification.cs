using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class ClearingSystemIdentification
    {
        private string _code;
        private string _proprietary;

        [XmlElement("Cd")]
        [MinLength(1), MaxLength(5)]
        public string Code
        {
            get { return _code; }
            set { _code = string.IsNullOrEmpty(value) ? null : value.Length > 5 ? value.Substring(0, 5) : value; }
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
