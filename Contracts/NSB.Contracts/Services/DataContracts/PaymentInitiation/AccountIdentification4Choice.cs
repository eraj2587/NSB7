using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class AccountIdentification4Choice
    {
        [XmlElement("IBAN")]
        [RegularExpression(@"[A-Z]{2,2}[0-9]{2,2}[a-zA-Z0-9]{1,30}")]
        public string IbanIdentifier { get; set; }

        [XmlElement("Othr")]
        public GenericAccountIdentification GenericAccountIdentification { get; set; }
    }
}
