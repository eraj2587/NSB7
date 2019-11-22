using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts.CustomerContracts;
using NSB.Contracts.Services.DataContracts.Entities;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface ICustomerQuery
    {
        [OperationContract]
        Validated<CustomerDetailsResult> GetCustomerDetails(int clientId);
        
        [OperationContract]
        Validated<CustomerAccountInfoSearchResult> GetCustomerAccountInfo(CustomerAccountInfoSearchRequest request);

        [OperationContract]
        Validated<CustomerUsersResult> GetCustomerUsers(int clientId);
    }
}
