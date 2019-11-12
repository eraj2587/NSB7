using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ReleaseRulesContracts
{

    [DataContract]
    public class WindowsTimeZone
    {
        [DataMember]
        public int TimeZoneId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string StandardName { get; set; }
        [DataMember]
        public DateTime? CreatedDate { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public int? UpdatedBy { get; set; }
    }
}
