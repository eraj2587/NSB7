using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class SettingValue
    {
        [DataMember]
        public int SettingId { get; set; }

        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public int ItemId { get; set; }

        [DataMember]
        public int? IntVal { get; set; }

        [DataMember]
        public float? FloatVal { get; set; }

        [DataMember]
        public DateTime? DateTimeVal { get; set; }

        [DataMember]
        public char? CharVal { get; set; }

        [DataMember]
        public int? SourceEntityId { get; set; }
    }
}
