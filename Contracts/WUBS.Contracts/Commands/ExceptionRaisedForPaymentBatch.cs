using System;
using WUBS.Contracts.Events;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.MonitoringService")]
    public class ExceptionRaisedForPaymentBatch
    {
        public long PaymentBatchId { get; set; }
        public string ExceptionCode { get; set; }
        public DateTime TimeOfException { get; set; }
    }
}
