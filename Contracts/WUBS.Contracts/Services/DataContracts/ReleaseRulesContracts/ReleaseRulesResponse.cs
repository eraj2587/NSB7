using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    [DataContract]
    public class NostroBankAccountDetailsResponse
    {
        [DataMember]
        public List<NostroBankAccountDetail> NostroBankAccountDetails { get; set; }
    }

    [DataContract]
    public class PaymentReleaseRuleResponse
    {
        [DataMember]
        public int NostroBankAccountChannelId { get; set; }
        [DataMember]
        public DateTime AchievablePaymentReleaseStartDateTime { get; set; }
        [DataMember]
        public DateTime AchievablePaymentReleaseDeadlineDateTime { get; set; }
        [DataMember]
        public DateTime AchievablePaymentValueDate { get; set; }
        [DataMember]
        public DateTime ActualValueDate { get; set; }
        [DataMember]
        public DateTime PaymentReleaseRulesTimeoutExpirationDateTime { get; set; }
    }
}