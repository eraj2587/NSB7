using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class GenericFinancialIdentification
    {
        private string _id;
        private string _issuer;

        [XmlElement("Id")]
        [MinLength(1), MaxLength(35)]
        public string Id
        {
            get { return _id; }
            set { _id = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("SchmeNm")]
        public CategoryPurpose SchemeName { get; set; }

        [XmlElement("Issr")]
        [MinLength(1), MaxLength(35)]
        public string Issuer
        {
            get { return _issuer; }
            set { _issuer = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }
    }
}
