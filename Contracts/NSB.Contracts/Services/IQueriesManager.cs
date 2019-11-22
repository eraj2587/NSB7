using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Services.DataContracts;
using NSB.Contracts.Services.Faults;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
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