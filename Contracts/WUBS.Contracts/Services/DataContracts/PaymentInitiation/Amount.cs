using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class Amount
    {
        [XmlElement("InstdAmt")]
        public CurrencyAndAmount CurrencyAndAmount { get; set; }
    }
}
