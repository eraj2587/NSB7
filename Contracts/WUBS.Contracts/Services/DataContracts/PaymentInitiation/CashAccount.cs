using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class CashAccount
    {
        private string _name;

        [XmlElement("Id")]
        public AccountIdentification4Choice AccountIdentification4Choice { get; set; }

        [XmlElement("Tp")]
        public CashAccountType AccountType { get; set; }

        [XmlElement("Nm")]
        [MinLength(1), MaxLength(70)]
        public string Name
        {
            get { return _name; }
            set { _name = string.IsNullOrEmpty(value) ? null : value.Length > 70 ? value.Substring(0, 70) : value; }
        }
    }
}
