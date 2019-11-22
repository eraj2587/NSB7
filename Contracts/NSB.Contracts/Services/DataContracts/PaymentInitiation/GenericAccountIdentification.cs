using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class GenericAccountIdentification
    {
        private string _id;

        [XmlElement("Id")]
        [MinLength(1), MaxLength(34)]
        public string Id
        {
            get { return _id; }
            set { _id = string.IsNullOrEmpty(value) ? null : value.Length > 34 ? value.Substring(0, 34) : value; }
        }
    }
}
