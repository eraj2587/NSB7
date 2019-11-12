using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceCategory
    {
        [DataMember]
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "categoryName")]
        public string CategoryName { get; set; }
    }
}
