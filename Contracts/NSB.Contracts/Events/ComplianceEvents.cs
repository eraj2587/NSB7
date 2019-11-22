using System;
using NSB.Contracts.Services.DataContracts.ComplianceContracts;

namespace NSB.Contracts.Events
{
    [Endpoint("NSB.Endpoints.Compliance")]
    public interface IComplianceScanUpdate
    {
        long Identifier { get; set; }
        ComplianceScanStatus ComplianceStatus { get; set; }
        Source Source { get; set; }
        DateTime? ValidityDate { get; set; }
    }

    [Endpoint("NSB.Endpoints.Compliance")]
    public interface IComplianceScanException
    {
        long Identifier { get; set; }
        ComplianceScanStatus ComplianceStatus { get; set; }
        string Reason { get; set; }
        Source Source { get; set; }
    }
}
