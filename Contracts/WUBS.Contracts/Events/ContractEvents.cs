using System.Collections.Generic;

namespace WUBS.Contracts.Events
{

    [Endpoint("WUBS.Endpoints.Contracts")]
    public interface IContractsCreatedForOrder
    {
        string OrderId { get; set; }
        IEnumerable<string> Contracts { get; set; }
    }

}