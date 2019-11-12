using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class CurrencyAndAmount
    {
        [XmlAttribute("Ccy")]
        [RegularExpression(@"[A-Z]{3,3}")]
        public string Currency { get; set; }

        [XmlText] 
        public string Value { get; set; }
    }
}
