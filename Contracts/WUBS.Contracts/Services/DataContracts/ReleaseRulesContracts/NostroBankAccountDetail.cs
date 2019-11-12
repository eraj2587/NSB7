using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    public class NostroBankAccountDetail : NostroBankAccount
    {
        [DataMember]
        public int NostroBankAccountChannelId { get; set; }
        //public int NostroBankAccountId { get; set; }
        [DataMember]
        public int ClearingTypeId { get; set; }
        [DataMember]
        public char IsOutgoingPayment { get; set; }
        [DataMember]
        public int PreferredMsgFormat { get; set; }
        [DataMember]
        public int ProcessingDays { get; set; }
        [DataMember]
        public int TimeZoneId { get; set; }
        [DataMember]
        public TimeSpan AutoReleaseStartTime { get; set; }
        [DataMember]
        public TimeSpan ReleaseDeadlineTime { get; set; }
        [DataMember]
        public int ChannelBusinessDays { get; set; }
        [DataMember]
        public List<NostroBankAccountChannelReleaseRule> ReleaseRuleList { get; set; }
    }
}