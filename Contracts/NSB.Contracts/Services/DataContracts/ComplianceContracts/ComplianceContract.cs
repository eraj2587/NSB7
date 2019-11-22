using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceContact
    {
        [DataMember]
        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "additionalPhone")]
        public string AdditionalPhone { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "additionalFax")]
        public string AdditionalFax { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "additionalEmail")]
        public string AdditionalEmail { get; set; }
    }
}
