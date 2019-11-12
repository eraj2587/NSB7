using Newtonsoft.Json;
using System;
using WUBS.Contracts.Events;
using WUBS.Contracts.Services.DataContracts.Monitoring;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.MonitoringService")]
    public class PaymentMonitoring : IMonitoring
    {
        public PaymentMonitoring()
        {
            this.CreatedDate = DateTime.UtcNow;
        }
        public int EntityType { get; set; }
        public long EntityId { get; set; }
        public int EventId { get; set; }
        public PaymentMonitoringAdditionalInfo AdditionalInformation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; private set; }
        public string AdditionalInfo
        {
            get { return JsonConvert.SerializeObject(this.AdditionalInformation); }
        }
    }
}
