using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class GenericOrganisationIdentification
    {
        private string _id;

        [XmlElement("Id")]
        [MinLength(1), MaxLength(35)]
        public string Id
        {
            get { return _id; }
            set { _id = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("SchmeNm")]
        public CategoryPurpose SchemeName { get; set; }
    }
}
