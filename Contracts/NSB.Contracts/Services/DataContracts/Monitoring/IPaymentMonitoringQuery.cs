using System.Collections.Generic;
using System.ServiceModel;
using NSB.Utilities.Common;

namespace NSB.Contracts.Services.DataContracts.Monitoring
{
    //If you add anything Here need to be added in Monitoring Ends NSB.Contracts Folder
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IPaymentMonitoringQuery
    {
        [OperationContract]
        PaymentsMonitoringResponse GetPaymentsMonitoringResponse(PaymentMonitoringRequest request);
        [OperationContract]
        ConcurrentList<PaymentsCount> GetPaymentStatistics(List<string> statisticsName);
    }
}
