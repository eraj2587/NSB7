
using NServiceBus;
using System;
using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.MonitoringService")]
    public class ExceptionRaisedForPayment : ICommand
    {
        public long PaymentId { get; set; }
        public string ExceptionCode { get; set; }
        public DateTime TimeOfException { get; set; }
    }
}
