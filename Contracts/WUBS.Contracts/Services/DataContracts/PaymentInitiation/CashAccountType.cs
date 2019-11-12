using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class CashAccountType
    {
        private string _proprietary;

        [XmlElement("Prtry")]
        [MinLength(1), MaxLength(35)]
        public string Proprietary
        {
            get { return _proprietary; }
            set { _proprietary = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }
    }
}
