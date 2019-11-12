using System.Collections.Generic;
using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts;
using WUBS.Contracts.Services.Faults;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IQueriesManager
    {
        [OperationContract]
        [FaultContract(typeof(InvalidCurrencyFault), Action = "InvalidCurrencyFault")]
        [FaultContract(typeof(InvalidCustomerFault), Action = "InvalidCustomerFault")]
        IEnumerable<HoldingBalance> GetHoldingBalance(string customerId, Currency currency);

        [OperationContract]
        VirtualAccountActivityResponse GetHoldingBalanceHistory(VirtualAccountActivityQuery query);

        [OperationContract]
        [FaultContract(typeof(CustomerNotEligibleFault), Action = "CustomerNotEligibleFault")]
        [FaultContract(typeof(InvalidCustomerFault), Action = "InvalidCustomerFault")]
        IEnumerable<CurrencyDetails> GetHoldingCurrencies(string customerId);


        [OperationContract]
        CompleteOrder GetOrder(long id);
    }

}