using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IOrderQuery
    {
        [OperationContract]
        Validated<OrderForRepurchaseResult> GetOrderForRepurchase(GetOrderForRepurchaseRequest request);
    }
}
