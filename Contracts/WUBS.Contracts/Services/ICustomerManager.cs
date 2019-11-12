using System.Collections.Generic;
using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts;
using WUBS.Contracts.Services.DataContracts.CustomerContracts;
using WUBS.Contracts.Services.Faults;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface ICustomerManager
    {
        [OperationContract]
        [FaultContract(typeof(InvalidCurrencyFault), Action = "InvalidCurrencyFault")]
        [FaultContract(typeof(InvalidCustomerFault), Action = "InvalidCustomerFault")]
        Customer GetCustomerById(int clientId);

        [OperationContract]
        Customer GetMassPayCustomerById(string externalCustomerId, string partnerCommonName);

        [OperationContract]
        [FaultContract(typeof(InvalidCurrencyFault), Action = "InvalidCurrencyFault")]
        [FaultContract(typeof(InvalidCustomerFault), Action = "InvalidCustomerFault")]
        bool IsCustomerEnabledForApplication(int clientId, int applicationId);

        [OperationContract]
        [FaultContract(typeof(InvalidCurrencyFault), Action = "InvalidCurrencyFault")]
        [FaultContract(typeof(InvalidCustomerFault), Action = "InvalidCustomerFault")]
        List<SearchCustomerResponse> SearchCustomer(SearchCustomerRequest searchCustomerRequest);

        [OperationContract]
        [FaultContract(typeof(InvalidCustomerFault), Action = "InvalidCustomerFault")]
        List<Customer> GetClientsUsingClientIdAndDescriptionWithOutOfficePermission(CustomerAccountInfoSearchRequest searchRequest);

    }
}
