using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ComplianceContracts
{
    [DataContract]
    [KnownType(typeof(SenderBankAccount))]
    [KnownType(typeof(RemitterBankAccount))]
    [KnownType(typeof(RecipientBankAccount))]
    [KnownType(typeof(IntermediaryBankAccount))]
    public class ComplianceBankAccount
    {
        [DataMember]
        [JsonProperty(PropertyName = "accountID")]
        public string AccountId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "type")]
        public string BankEntityType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "accountType")]
        public string AccountType { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "category")]
        public ComplianceCategory Category { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "name")]
        public string BankName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "accountNo")]
        public string BankAccountNumber { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "accountStatus")]
        public string AccountStatusName { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "address")]
        public ComplianceAddress Address { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "code")]
        public string BankCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "IBAN")]
        public string BankIBAN { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "reference")]
        public string Reference { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "beneficiaryID")]
        public string BankBeneficiaryId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "customerID")]
        public string BankCustomerId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "domesticRoutingCD")]
        public string DomesticRoutingCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "SWIFTCode")]
        public string SwiftCode { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "sourcePlatformID")]
        public string SourcePlatformId { get; set; }
    }

    [DataContract]
    public class SenderBankAccount : ComplianceBankAccount { }

    [DataContract]
    public class RemitterBankAccount : ComplianceBankAccount { }

    [DataContract]
    public class RecipientBankAccount : ComplianceBankAccount { }

    [DataContract]
    public class IntermediaryBankAccount : ComplianceBankAccount { }

    [DataContract]
    public enum BankEntityType
    {
        [EnumMember]
        SenderBank,
        [EnumMember]
        RemitterBank,
        [EnumMember]
        RecipientBank,
        [EnumMember]
        IntermediaryBank
    }
}
