using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{

    [DataContract]
    public class ComplianceAddress
    {
        [DataMember]
        [JsonProperty(PropertyName = "line1")]
        public string AddressLine1 { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "line2")]
        public string AddressLine2 { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "line3")]
        public string AddressLine3 { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "stateOrProvinceCode")]
        public string StateOrProvinceCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "stateOrProvinceName")]
        public string StateOrProvinceName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "countryName")]
        public string CountryName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "compositeAddr")]
        public string AddressField { get; set; }
    }
}
