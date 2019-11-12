using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceReceiverInformation
    {
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "countryName")]
        public string CountryName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "mobilePhoneNumber")]
        public string MobilePhoneNumber { get; set; }
    }
}
