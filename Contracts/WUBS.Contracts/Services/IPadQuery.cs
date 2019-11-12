using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts.CustomerContracts;
using WUBS.Contracts.Services.DataContracts.Transactions;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IPadQuery
    {
        [OperationContract]
        PadTransactionSearchResult GetTransactions(PadTransactionFilter filter);

        [OperationContract]
        CustomerAccountInfoSearchResult GetCustomers(CustomerAccountInfoSearchRequest request);
    }
}
