using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class Amount
    {
        [XmlElement("InstdAmt")]
        public CurrencyAndAmount CurrencyAndAmount { get; set; }
    }
}
