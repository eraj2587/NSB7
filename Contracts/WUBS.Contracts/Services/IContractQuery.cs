using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts;

namespace WUBS.Contracts.Services
{
    [ServiceContract]
    public interface IContractQuery
    {
        [OperationContract]
        Validated<ContractResponse> GetContracts(bool useCctService, ContractQuery query);

        [OperationContract]
        Validated<DrawdownResponse> GetDrawdowns(bool useCctService, DrawdownQuery query);

        [OperationContract]
        Validated<ContractActivityResponse> GetContractActivities(bool useCctService, ContractActivityQuery query);
    }
}
