using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts.CurrencyContracts;

namespace NSB.Contracts.Services
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
