using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.ReleaseRulesContracts
{
    [DataContract]
    public class NostroBankAccountDetailsRequest
    {
        [DataMember]
        public int UniqueRowId { get; set; }
        [DataMember]
        public ReleaseRulesDataType ReleaseRulesDataType { get; set; }

        [DataMember]
        public object OldData { get; set; }

        [DataMember]
        public object NewData { get; set; }
    }

    [DataContract]
    public class PaymentReleaseRuleRequest
    {
        [DataMember]
        public int NostroBankAccountChannelId { get; set; }
        [DataMember]
        public int PaymentMethodId { get; set; }

        [DataMember]
        public DateTime ValueDate { get; set; }
    }
}