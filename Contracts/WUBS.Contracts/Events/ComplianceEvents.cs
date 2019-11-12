using System;
using WUBS.Contracts.Services.DataContracts.ComplianceContracts;

namespace WUBS.Contracts.Events
{
    [Endpoint("WUBS.Endpoints.Compliance")]
    public interface IComplianceScanUpdate
    {
        long Identifier { get; set; }
        ComplianceScanStatus ComplianceStatus { get; set; }
        Source Source { get; set; }
        DateTime? ValidityDate { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Compliance")]
    public interface IComplianceScanException
    {
        long Identifier { get; set; }
        ComplianceScanStatus ComplianceStatus { get; set; }
        string Reason { get; set; }
        Source Source { get; set; }
    }
}
