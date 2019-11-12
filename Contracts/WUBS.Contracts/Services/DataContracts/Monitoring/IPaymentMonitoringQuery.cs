using System.Collections.Generic;
using System.ServiceModel;
using WUBS.Utilities.Common;

namespace WUBS.Contracts.Services.DataContracts.Monitoring
{
    //If you add anything Here need to be added in Monitoring Ends WUBS.Contracts Folder
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IPaymentMonitoringQuery
    {
        [OperationContract]
        PaymentsMonitoringResponse GetPaymentsMonitoringResponse(PaymentMonitoringRequest request);
        [OperationContract]
        ConcurrentList<PaymentsCount> GetPaymentStatistics(List<string> statisticsName);
    }
}
