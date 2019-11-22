using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using NSB.Contracts.Services.DataContracts.Enums;

namespace NSB.Contracts.Services.DataContracts
{
    public class InstructionForCreditorAgent
    {
        private string _instructionInformation;

        [XmlElement("Cd")]
        public InstructionForCreditorAgentCode InstructionForCreditorAgentCode { get; set; }

        [XmlElement("InstrInf")]
        [MinLength(1), MaxLength(210)]
        public string InstructionInformation
        {
            get { return _instructionInformation; }
            set { _instructionInformation = string.IsNullOrEmpty(value) ? null : value.Length > 210 ? value.Substring(0, 210) : value; }
        }
    }
}
