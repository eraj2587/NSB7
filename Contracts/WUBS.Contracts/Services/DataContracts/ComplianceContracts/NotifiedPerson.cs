using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WUBS.Contracts.Services.DataContracts
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
