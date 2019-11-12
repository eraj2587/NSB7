using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts.CustomerContracts;
using WUBS.Contracts.Services.DataContracts.Entities;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
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
