using System;
using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.PaymentReleasePolicy")]
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
