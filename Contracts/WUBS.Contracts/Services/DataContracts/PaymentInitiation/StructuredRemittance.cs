using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class StructuredRemittance
    {
        [XmlElement("AddtlRmtInf")]
        [MinLength(1), MaxLength(140)]
        public List<string> AdditionalRemittanceInfo { get; set; }
    }
}