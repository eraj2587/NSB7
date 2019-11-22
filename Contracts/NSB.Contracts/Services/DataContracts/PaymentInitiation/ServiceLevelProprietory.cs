using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class ServiceLevelProprietory
    {
        private string _proprietary;
        private string _code;

        [XmlElement("Cd")]
        [MinLength(1), MaxLength(4)]
        public string Code
        {
            get { return _code; }
            set { _code = string.IsNullOrEmpty(value) ? null : value.Length > 4 ? value.Substring(0, 4) : value; }
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
