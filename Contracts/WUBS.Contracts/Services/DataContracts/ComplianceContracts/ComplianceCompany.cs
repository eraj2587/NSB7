using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceCompany
    {
        [DataMember]
        [JsonProperty(PropertyName = "industryType")]
        public string IndustryType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "legalName")]
        public string LegalName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "tradeName")]
        public string TradeName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "customerBusinessType")]
        public string CustomerBusinessType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "incorporationState")]
        public string IncorporationState { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "customerCategory")]
        public string CustomerCategory { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "LEI")]
        public string LEI { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "DUNSNumber")]
        public string DUNSNumber { get; set; }
    }
}
