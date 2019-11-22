using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    public class LocalInstrumentChoice
    {
        private string _cd;

        [XmlElement("Cd")]
        [MinLength(1), MaxLength(35)]
        public string Cd
        {
            get { return _cd; }
            set { _cd = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }
    }
}
