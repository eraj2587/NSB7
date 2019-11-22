using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Services.DataContracts;
using NSB.Contracts.Services.DataContracts.CustomerContracts;
using NSB.Contracts.Services.Faults;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
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
