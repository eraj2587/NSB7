
using NServiceBus;
using System;
using NSB.Contracts.Events;

namespace NSB.Contracts.Commands
{
    [Endpoint("NSB.Endpoints.MonitoringService")]
    public class ExceptionRaisedForPayment : ICommand
    {
        public long PaymentId { get; set; }
        public string ExceptionCode { get; set; }
        public DateTime TimeOfException { get; set; }
    }
}
