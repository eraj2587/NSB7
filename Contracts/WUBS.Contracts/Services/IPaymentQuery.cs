using System.Collections.Generic;
using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts;
using WUBS.Utilities.Common;
namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IPaymentQuery
    {
        [OperationContract]
        PaymentResponse GetPayment(PaymentRequest request);

        [OperationContract]
        PaymentsResponse GetPayments(PaymentsRequest request);

        [OperationContract]
        PaymentGeneralDetailsResponse GetPaymentGeneralDetails(string paymentId);
        
        [OperationContract]
        PaymentClientDetailResponse GetClientDetailsForPayment(string paymentId);

        [OperationContract]
        BeneficiaryDetailsResponse GetBeneDetails(string paymentId);

        [OperationContract]
        PaymentStoreResponse SearchPayments(PaymentStoreRequest storeRequest);

        [OperationContract]
        PaymentStoreResponse SearchPaymentsV2(PaymentStoreRequest storeRequest);

        [OperationContract]
        ConcurrentList<PaymentsCount> GetAllPaymentStatistics();

        [OperationContract]
        ConcurrentList<PaymentsCount> GetPaymentStatistics(List<string> statisticsName);

        [OperationContract]
        PaymentStoreResponse GetPaymentStatisticsDetails(PaymentStoreRequest storeRequest);
    }
}
