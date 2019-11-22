using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    [DataContract]
    public class ChannelBusinessDay
    {
        [DataMember]
        public int ChannelBusinessDayId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public bool Monday { get; set; }
        [DataMember]
        public bool Tuesday { get; set; }
        [DataMember]
        public bool Wednesday { get; set; }
        [DataMember]
        public bool Thursday { get; set; }
        [DataMember]
        public bool Friday { get; set; }
        [DataMember]
        public bool Saturday { get; set; }
        [DataMember]
        public bool Sunday { get; set; }
    }
}
