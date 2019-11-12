namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts
{
    public enum ContractStatus : byte
    {
        Undefined = 0,
        Created = 1,
        Booked = 2,
        Verified = 3,
        Rejected = 4,
        Cancelled = 5,
        Completed = 6,
        Expired = 7
    }

    public enum ContractType : byte
    {
        Undefined = 0,
        Spot = 1,
        RegularFw = 2,
        Ndf = 3
    }

    public enum ContractExecutionMethod : byte
    {
        Undefined = 0,
        Regular = 1,
        Offsetting = 2,
        Extension = 3,
        Predelivery = 4,
        AutoExtension = 5
    }

    public enum ContractConfirmationMethod : byte
    {
        Undefined = 0,
        Fax = 1,
        Electronic = 2
    }

    public enum ContractLegType : byte
    {
        Undefined = 0,
        Near = 1,
        Far = 2
    }
}
