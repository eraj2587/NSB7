namespace WUBS.Contracts.Events
{
    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface INewLimitOrderSubmitted
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface IManualPendingLimitOrderCreated
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface IAutoFillLimitOrderCreated
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface IManualFillLimitOrderCreated
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderRejected
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface IManualFillLimitOrderCreationFailed
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderFilled
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderDidNotFill
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface IContractCreated
    {
        string LimitOrderId { get; set; }
    }


    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderExpired
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderCancelled
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderPendingCancel
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderRejectedCancel
    {
        string LimitOrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Hedging")]
    public interface ILimitOrderUpdated
    {
        string LimitOrderId { get; set; }
    }
}