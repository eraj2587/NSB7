namespace NSB.Contracts.Events
{
    [Endpoint("NSB.Endpoints.Orders")]
    public interface IOrderCommitted
    {
        string OrderId { get; set; }
    }

    [Endpoint("NSB.Endpoints.Orders")]
    public interface IOrderBooked
    {
        string OrderId { get; set; }
    }
}