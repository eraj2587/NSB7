
using NServiceBus;
using System;
using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.MonitoringService")]
    public class ExceptionRaisedForInTransitPayment : ICommand
    {
        public string ConfirmationNo { get; set; }
        public string ExceptionCode { get; set; }
        public DateTime TimeOfException { get; set; }
    }
}
