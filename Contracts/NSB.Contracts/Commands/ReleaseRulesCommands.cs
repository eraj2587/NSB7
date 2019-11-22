using System;
using NSB.Contracts.Events;

namespace NSB.Contracts.Commands
{
    [Endpoint("NSB.Endpoints.ReleaseRules")]
    public class RefreshPaymentReleaseRulesCommand
    {
        public long PaymentId { get; set; }
        public int HoldId { get; set; }
        public int PaymentMethodId { get; set; }
        public int NostroBankAccountChannelId { get; set; }
        public DateTime ValueDate { get; set; }

    }
}