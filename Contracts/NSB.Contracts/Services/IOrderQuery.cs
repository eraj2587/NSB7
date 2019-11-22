using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts.Orders;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IOrderQuery
    {
        [OperationContract]
        Validated<OrderForRepurchaseResult> GetOrderForRepurchase(GetOrderForRepurchaseRequest request);
    }
}
