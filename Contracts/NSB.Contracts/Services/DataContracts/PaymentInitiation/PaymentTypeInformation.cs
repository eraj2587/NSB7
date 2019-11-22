using System;
using System.Xml.Serialization;
using NSB.Contracts.Services.DataContracts.Enums;

namespace NSB.Contracts.Services.DataContracts
{
    public class PaymentTypeInformation
    {
        private string _sequenceTypeCode;

        [XmlElement("SvcLvl")]
        public ServiceLevelProprietory ServiceLevelProprietory { get; set; }
     
        [XmlElement("LclInstrm")]
        public LocalInstrumentChoice LocalInstrumentChoice { get; set; }

        [XmlElement("SeqTp")]
        public string SequenceType
        {
            get { return _sequenceTypeCode; }
            set { _sequenceTypeCode = string.IsNullOrEmpty(value) ? null : Enum.IsDefined(typeof(SequenceTypeCode), value) ? Enum.Parse(typeof(SequenceTypeCode), value).ToString() : null; }
        }

        [XmlElement("CtgyPurp")]
        public CategoryPurpose CategoryPurpose { get; set; }
    }
}
