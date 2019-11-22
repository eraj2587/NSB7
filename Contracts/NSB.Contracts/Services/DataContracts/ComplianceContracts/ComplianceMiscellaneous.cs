using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    public class ComplianceMiscellaneous
    {
        [DataMember]
        [JsonProperty(PropertyName = "accountCode")]
        public string AccountCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "accountNo")]
        public string AccountNo { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "individualFlag")]
        public string IndividualFlag { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "isSWB")]
        public string IsSWB { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "branchCode")]
        public string BranchCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "branchType")]
        public string BranchType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "salesforceAMLRiskRating")]
        public string SalesforceAMLRiskRating { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "complianceCustomerTypeKey")]
        public string ComplianceCustomerTypeKey { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "complianceIndustryTypeKey")]
        public string ComplianceIndustryTypeKey { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "owningLegalEntityName")]
        public string OwningLegalEntityName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "retailAuthorizedUser")]
        public int? IsRetailAuthorizedUser { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "thirdPartyInstructor")]
        public int? IsThirdPartyInstructor { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "beneficiaryRemitter")]
        public int? IsBeneficiaryRemitter { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "sourcePlatformID")]
        public string SourcePlatformId { get; set; }
    }
}
