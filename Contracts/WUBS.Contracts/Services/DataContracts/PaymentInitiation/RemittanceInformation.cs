using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class RemittanceInformation
    {
        [XmlElement("Ustrd")]
        [MinLength(1), MaxLength(140)]
        public List<string> Unstructured { get; set; }

		[XmlElement("Strd")]
		public List<StructuredRemittance> Structured { get; set; }
	}
}
