using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class PartyInformation
    {
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "alternateName")]
        public string AlternateName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "alternateShipToName")]
        public string AlternateShipToName { get; set; }
    }
}
