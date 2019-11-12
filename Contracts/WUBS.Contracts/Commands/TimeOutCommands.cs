using NServiceBus;
using System;
using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{

    [Endpoint("WUBS.Endpoints.PaymentReleasePolicy")]
    public class PaymentStartTimeTimeoutCommand 
    {
        public long PaymentId { get; set; }
        public long PaymentInstructionId { get; set; }
        public DateTime PaymentReleaseRulesTimeoutExpirationDateTime { get; set; }
        public DateTime ActualValueDate { get; set; }
        public DateTime AchievablePaymentValueDate { get; set; }
        public DateTime AchievablePaymentReleaseStartDateTime { get; set; }
        public DateTime AchievablePaymentReleaseDeadline { get; set; }
        public int PaymentMethodId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.PaymentReleasePolicy")]
    public class TimeOutReleaseRulesCommand 
    {
        public long PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Client")]
    public class CreatePaymentForTestingCommand
    {
        public long PaymentId { get; set; }
    }


}
