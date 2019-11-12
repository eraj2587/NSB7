using System;
using WUBS.Contracts.Events;
using WUBS.Contracts.Services.DataContracts.ComplianceContracts;

namespace WUBS.Contracts.Commands
{
    [Endpoint("WUBS.Endpoints.ComplianceCctAdapter")]
    public class ResourceScan
    {
        public int EntityId { get; set; }
        public EntityType EntityType { get; set; }
        public RequestType RequestType { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Compliance")]
    public class ComplianceScan
    {
        public long Identifier { get; set; }
        public string Payload { get; set; }
        public EntityType EntityType { get; set; }
        public Source Source { get; set; }
    }
    [Endpoint("WUBS.Endpoints.ComplianceCctUpdate")]
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
