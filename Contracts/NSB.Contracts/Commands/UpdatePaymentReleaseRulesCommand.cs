using System;
using NSB.Contracts.Events;

namespace NSB.Contracts.Commands
{
    [Endpoint("NSB.Endpoints.PaymentReleasePolicy")]
    public class UpdatePaymentReleaseRulesCommand
    {        
        public long PaymentId { get; set; }
        public int HoldId { get; set; }
        public DateTime AchievablePaymentReleaseStartDateTime { get; set; }
        public DateTime AchievablePaymentReleaseDeadline { get; set; }
        public DateTime AchievablePaymentValueDate { get; set; }
        public DateTime ActualValueDate { get; set; }
        public DateTime PaymentReleaseRulesTimeoutExpirationDateTime { get; set; }
        public int PaymentMethodId { get; set; }
    }
}
