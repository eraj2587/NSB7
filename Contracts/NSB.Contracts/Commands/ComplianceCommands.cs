using System;
using NSB.Contracts.Events;
using NSB.Contracts.Services.DataContracts.ComplianceContracts;

namespace NSB.Contracts.Commands
{
    [Endpoint("NSB.Endpoints.ComplianceCctAdapter")]
    public class ResourceScan
    {
        public int EntityId { get; set; }
        public EntityType EntityType { get; set; }
        public RequestType RequestType { get; set; }
    }

    [Endpoint("NSB.Endpoints.Compliance")]
    public class ComplianceScan
    {
        public long Identifier { get; set; }
        public string Payload { get; set; }
        public EntityType EntityType { get; set; }
        public Source Source { get; set; }
    }
    [Endpoint("NSB.Endpoints.ComplianceCctUpdate")]
    public class ResourceScanUpdate
    {
        public long EntityId { get; set; }
        public ComplianceProcessingStatus ComplianceProcessingStatus { get; set; }
        public ComplianceScanStatus ComplianceStatus { get; set; }
        public bool IsRescan { get; set; }
        public DateTime? ValidityDate { get; set; }
        public EntityType EntityType { get; set; }
    }
}
