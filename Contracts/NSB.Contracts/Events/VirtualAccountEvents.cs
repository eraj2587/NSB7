namespace NSB.Contracts.Events
{
    [Endpoint("NSB.Endpoints.VirtualAccounts")]
    public interface IFundsAppliesForOrder
    {
        string OrderId { get; set; }
    }

    [Endpoint("NSB.Endpoints.VirtualAccounts")]
    public interface IFundsWithdrawnForPayment
    {
        string PaymentId { get; set; }
    }

    [Endpoint("NSB.Endpoints.VirtualAccounts")]
    public interface IFundsDepositedForPayment
    {
        string PaymentId { get; set; }
    }
}