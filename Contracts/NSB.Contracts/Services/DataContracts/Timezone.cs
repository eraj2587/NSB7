using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class Timezone
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int GMTOffset { get; set; }

        [DataMember]
        public int DSTPlanId { get; set; }
    }
}
