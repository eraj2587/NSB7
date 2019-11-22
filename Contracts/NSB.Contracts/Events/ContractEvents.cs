using System.Collections.Generic;

namespace NSB.Contracts.Events
{

    [Endpoint("NSB.Endpoints.Contracts")]
    public interface IContractsCreatedForOrder
    {
        string OrderId { get; set; }
        IEnumerable<string> Contracts { get; set; }
    }

}