using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    public class NostroBankAccount
    {
        [DataMember]
        public int NostroBankAccountId { get; set; }
        [DataMember]
        public string NostroBankAccountCode { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string CurrencyCode { get; set; }
        [DataMember]
        public string CountryCode { get; set; }
        [DataMember]
        public bool CountryHolidayApplicable { get; set; }
    }
}