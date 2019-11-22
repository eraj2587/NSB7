using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class PaymentIdentification
    {
        private string _instrId;
        private string _endToEndId;

        [XmlElement("InstrId")]
        [MinLength(1), MaxLength(35)]
        public string InstrId
        {
            get { return _instrId; }
            set { _instrId = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }

        [XmlElement("EndToEndId")]
        [MinLength(1), MaxLength(35)]
        public string EndToEndId
        {
            get { return _endToEndId; }
            set { _endToEndId = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }
    }
}
