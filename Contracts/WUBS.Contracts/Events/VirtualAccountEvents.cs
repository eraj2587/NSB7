namespace WUBS.Contracts.Events
{
    [Endpoint("WUBS.Endpoints.VirtualAccounts")]
    public interface IFundsAppliesForOrder
    {
        string OrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.VirtualAccounts")]
    public interface IFundsWithdrawnForPayment
    {
        string PaymentId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.VirtualAccounts")]
    public interface IFundsDepositedForPayment
    {
        string PaymentId { get; set; }
    }
}