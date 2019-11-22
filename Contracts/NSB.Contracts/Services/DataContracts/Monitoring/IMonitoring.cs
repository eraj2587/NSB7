using System;

namespace NSB.Contracts.Services.DataContracts.Monitoring
{
    public interface IMonitoring
    {
        int EntityType { get; set; }

        long EntityId { get; set; }

        int EventId { get; set; }
        string AdditionalInfo { get; }

        string CreatedBy { get; set; }

        DateTime CreatedDate { get; }
    }
}
