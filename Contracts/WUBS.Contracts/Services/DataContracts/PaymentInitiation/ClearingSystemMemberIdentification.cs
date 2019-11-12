using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    public class ClearingSystemMemberIdentification
    {
        private string _memberId;

        [XmlElement("ClrSysId")]
        public ClearingSystemIdentification ClearingSystemIdentification { get; set; }

        [XmlElement("MmbId")]
        [MinLength(1), MaxLength(35)]
        public string MemberId
        {
            get { return _memberId; }
            set { _memberId = string.IsNullOrEmpty(value) ? null : value.Length > 35 ? value.Substring(0, 35) : value; }
        }
    }
}
