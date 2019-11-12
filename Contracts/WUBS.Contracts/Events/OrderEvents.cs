namespace WUBS.Contracts.Events
{
    [Endpoint("WUBS.Endpoints.Orders")]
    public interface IOrderCommitted
    {
        string OrderId { get; set; }
    }

    [Endpoint("WUBS.Endpoints.Orders")]
    public interface IOrderBooked
    {
        string OrderId { get; set; }
    }
}