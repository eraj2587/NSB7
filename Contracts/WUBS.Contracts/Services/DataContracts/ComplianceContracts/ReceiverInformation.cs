using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class ReceiverInformation
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
