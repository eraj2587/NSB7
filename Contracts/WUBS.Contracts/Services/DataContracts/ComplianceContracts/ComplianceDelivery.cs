using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceDelivery
    {
        [DataMember]
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "address")]
        public ComplianceAddress Address { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "statusName")]
        public string StatusName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "creationDate")]
        public string CreationDate { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "lastUpdated")]
        public string LastUpdated { get; set; }
    }
}
