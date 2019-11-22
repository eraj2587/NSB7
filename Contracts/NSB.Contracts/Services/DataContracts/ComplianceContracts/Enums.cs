namespace NSB.Contracts.Services.DataContracts.ComplianceContracts
{
    public enum RequestType : byte
    {
        Undefined = 0,
        ScanOrder = 1,
        ReScanOrder = 2,
        ScanEntity = 3
    }

    public enum EntityType : byte
    {
        Undefined = 0,
        Payment = 1
    }

    public enum ComplianceProcessingStatus : byte
    {
        Started = 1,
        Created = 2,
        StatusUpdated = 3,
        Completed = 4,
        Exception = 5
    }

    public enum ComplianceScanStatus
    {
        Ready = 951,
        InProcess = 978,
        Split = 956,
        Suspect = 952,
        ConfirmHit = 953,
        Exception = 955,
        FalsePositive = 950,
        Complete = 954,
        Escalated = 949,
        ComplianceHold = 1201,
        ComplianceCancel = 1202,
        ComplianceBlocked = 1203
    }

    public enum ComplianceScanResult
    {
        NoHit,
        Hit
    }

    public enum ScanOption
    {
        NotFircosoft,
        Fircosoft = 2177
    }
    
    public enum ErrorCodes
    {
        InvalidRequest = 1001,
        InvalidStatusRequest = 1002,
        NoComplianceScanLogExists = 1003
    }

    public enum ScanStatus
    {
        Pass,
        Fail
    }

    public enum Reason : byte
    {
        NA = 0,
        CANCELLED = 1,
        REJECTED_AND_REPORTED = 2,
        BLOCKED_AND_REPORTED = 3,
        FALSE_POSITIVE_CANCEL = 4,
        OTHER = 5
    }

    public enum Source : byte
    {
        NSB,
        CCT
    }

    public enum ProcessForRescan : int
    {
        Processed = 0,
        Ready = 1,
        Pending = 2
    }
}
