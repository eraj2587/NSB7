using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class FinancialInstitutionIdentification
    {
        private string _name;

        [XmlElement("BIC")]
        [RegularExpression(@"[A-Z]{6,6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3,3}){0,1}")]
        public string Bic { get; set; }

        [XmlElement("BICFI")]
        [RegularExpression(@"[A-Z]{6,6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3,3}){0,1}")]
        public string BicFi { get; set; }

        [XmlElement("ClrSysMmbId")]
        public ClearingSystemMemberIdentification ClearingSystemMemberIdentification { get; set; }

        [XmlElement("Nm")]
        [MinLength(1), MaxLength(140)]
        public string Name
        {
            get { return _name; }
            set { _name = string.IsNullOrEmpty(value) ? null : value.Length > 140 ? value.Substring(0, 140) : value; }
        }

        [XmlElement("PstlAdr")]
        public PostalAddress PostalAddress { get; set; }

        [XmlElement("Othr")]
        public GenericFinancialIdentification GenericFinancialIdentification { get; set; }
    }
}
