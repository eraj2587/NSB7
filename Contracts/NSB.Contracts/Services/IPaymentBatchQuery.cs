using System;
using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Services.DataContracts;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IPaymentBatchQuery
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IEnumerable<PaymentBatch> GetPaymentBatchAndBatchDetailsByCreatedDate(DateTime beginDate, DateTime endDate, bool isOutgoing, int currencyId, int statusId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IEnumerable<PaymentBatch> GetPaymentBatchAndBatchDetailsByCreatedDateForPaging(DateTime beginDate, DateTime endDate, bool isOutgoing, int currencyId, int statusId, int pageIndex, int pageSize);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IEnumerable<PaymentBatch> GetPaymentBatchAndBatchDetailsByCreatedDateCurrency(DateTime beginDate,
            DateTime endDate, bool isOutgoing, string currency);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IEnumerable<PaymentFileMatch> GetPaymentFileComparison(int sourceId, bool isIncoming, int paymentBatchId, string incomingConfirmationNo);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string GetPaymentBatchFileBody(long paymentBatchId);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        IEnumerable<PaymentBatchDetail> GetPaymentBatchDetailsById(long paymentBatchId);
    }
}