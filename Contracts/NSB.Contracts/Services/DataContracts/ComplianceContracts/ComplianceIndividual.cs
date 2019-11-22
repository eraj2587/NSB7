using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceIndividual
    {
        [DataMember]
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "dateOfBirth")]
        public string DateofBirth { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "citizenshipCountryCode")]
        public string CitizenshipCountryCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationCode")]
        public string IdentificationCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationIssuer")]
        public string IdentificationIssuer { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationIssuerCountry")]
        public string IdentificationIssuerCountry { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "identificationTypeName")]
        public string IdentificationTypeName { get; set; }
    }
}
