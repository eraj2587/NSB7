using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class NotifiedPerson
    {
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
