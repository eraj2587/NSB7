using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts.MassPay;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IMassPayQuery
    {
        [OperationContract]
        Validated<MassPaySearchResult> GetPaymentByInstructionId(string instructionId);

        [OperationContract]
        Validated<MassPaySearchResult> GetPaymentByCustomerPaymentId(string customerPaymentId, string partnerCustomerId);

        [OperationContract]
        Validated<MassPaySearchResult> GetPaymentByBeneficiaryName(PaymentSearchBeneficiaryNameRequest beneficiaryNameRequest);

        [OperationContract]
        Validated<MassPaySearchResult> GetPaymentByBankAccountNumber(PaymentSearchBankAccountRequest bankAccountRequest);

        [OperationContract]
        Validated<MassPaySearchResult> GetPaymentByIrisPaymentId(int paymentId, string partnerCode);

        [OperationContract]
        Validated<PaymentDetailsResult> GetPaymentDetails(List<PaymentIdentifier> paymentIdentifiers);

        [OperationContract]
        Validated<PaymentDetailsResult> GetPaymentByGPGBatchId(string gpgBatchId);

        [OperationContract]
        PartnerResult GetPartners();
        
        [OperationContract]
        Validated<PaymentStatusHistoryResult> GetPaymentStatusHistory(string paymentId);
    }
}
