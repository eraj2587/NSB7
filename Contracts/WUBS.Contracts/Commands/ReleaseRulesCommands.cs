using System;
using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.ReleaseRules")]
    public class RefreshPaymentReleaseRulesCommand
    {
        public long PaymentId { get; set; }
        public int HoldId { get; set; }
        public int PaymentMethodId { get; set; }
        public int NostroBankAccountChannelId { get; set; }
        public DateTime ValueDate { get; set; }

    }
}