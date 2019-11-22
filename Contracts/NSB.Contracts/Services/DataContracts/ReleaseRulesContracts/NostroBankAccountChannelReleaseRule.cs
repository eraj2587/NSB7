using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    public class NostroBankAccountChannelReleaseRule
    {
        [DataMember]
        public long NostroBankAccountChannelReleaseRuleId { get; set; }
        [DataMember]
        public int NostroBankAccountChannelId { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime AchievableBankReleaseDate { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime AchievableBankReleaseStartDateTime { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime AchievableBankReleaseDeadlineDateTime { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime AchievableBankValueDate { get; set; }
        [DataMember]
        public DateTime TimeoutExpirationDateTime { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime EffectiveStartDateTime { get; set; }
        [DataMember]
        [Column(TypeName = "datetime2")]
        public DateTime EffectiveEndDateTime { get; set; }
    }
}