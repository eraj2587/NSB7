using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    [KnownType(typeof(CustomerParty))]
    [KnownType(typeof(ParentCustomerParty))]
    [KnownType(typeof(BranchParty))]
    [KnownType(typeof(BeneficiaryParty))]
    [KnownType(typeof(RemitterParty))]
    [KnownType(typeof(AuthorizedUserParty))]
    [KnownType(typeof(RetailAuthorizedUserParty))]
    public class ComplianceParty
    {
        [DataMember]
        [JsonProperty(PropertyName = "ID")]
        public string Id { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "type")]
        public string PartyType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public CompliancePartyInformation Name { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "address")]
        public ComplianceAddress Address { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "contact")]
        public ComplianceContact Contact { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "individual")]
        public ComplianceIndividual Individual { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "company")]
        public ComplianceCompany Company { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "misc")]
        public ComplianceMiscellaneous Miscellaneous { get; set; }
    }

    [DataContract]
    public class CustomerParty : ComplianceParty { }

    [DataContract]
    public class ParentCustomerParty : ComplianceParty { }

    [DataContract]
    public class BranchParty : ComplianceParty { }

    [DataContract]
    public class BeneficiaryParty : ComplianceParty { }

    [DataContract]
    public class RemitterParty : ComplianceParty { }

    [DataContract]
    public class AuthorizedUserParty : ComplianceParty { }

    [DataContract]
    public class RetailAuthorizedUserParty : ComplianceParty { }

    [DataContract]
    public enum PartyType
    {
        [EnumMember]
        Customer,
        [EnumMember]
        ParentCompanyforCustomer,
        [EnumMember]
        Branch,
        [EnumMember]
        Beneficiary,
        [EnumMember]
        Remitter,
        [EnumMember]
        AuthorizedUser
    }
}
