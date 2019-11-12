using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class StructuredRegulatoryReporting
    {
        private string _type;
        private string _code;
        private string _information;

        [XmlElement("Tp")]
        [MinLength(1), MaxLength(35)]
        public string Type
        {
            get { return _type; }
            set { _type = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("Dt")]
        public string Date { get; set; }

        [XmlElement("Ctry")]
        [RegularExpression(@"[A-Z]{2,2}")]
        public string Country { get; set; }

        [XmlElement("Cd")]
        [MinLength(1), MaxLength(10)]
        public string Code
        {
            get { return _code; }
            set { _code = string.IsNullOrEmpty(value) ? null : value.Length > 10 ? value.Substring(0, 10) : value; }
        }

        [XmlElement("Amt")]
        public Amount Amount { get; set; }

        [XmlElement("Inf")]
        [MinLength(1), MaxLength(89)]
        public string Information
        {
            get { return _information; }
            set { _information = string.IsNullOrEmpty(value) ? null : value.Length > 89 ? value.Substring(0, 89) : value; }
        }
    }
}
