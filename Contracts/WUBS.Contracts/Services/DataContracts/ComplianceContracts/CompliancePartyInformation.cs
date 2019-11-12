using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class CompliancePartyInformation
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
