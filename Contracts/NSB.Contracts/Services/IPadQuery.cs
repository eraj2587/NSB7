using System.ServiceModel;
using NSB.Contracts.Services.DataContracts.CustomerContracts;
using NSB.Contracts.Services.DataContracts.Transactions;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IPadQuery
    {
        [OperationContract]
        PadTransactionSearchResult GetTransactions(PadTransactionFilter filter);

        [OperationContract]
        CustomerAccountInfoSearchResult GetCustomers(CustomerAccountInfoSearchRequest request);
    }
}
