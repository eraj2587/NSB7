using System.Collections.Generic;
using System.ServiceModel;
using WUBS.Contracts.Common.Monads;
using WUBS.Contracts.Services.DataContracts.LineItems;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface ILineItemQuery
    {
        [OperationContract]
        Validated<LineItemSearchResult> GetLineItemByReferenceId(GetLineItemByReferenceIdRequest request);

        [OperationContract]
        Validated<LineItemSearchResult> GetLineItemByPayerPayeeAccount(GetLineItemByPayerPayeeAccountRequest request);

        [OperationContract]
        Validated<LineItemSearchResult> GetLineItemByPayerPayeeName(GetLineItemByPayerPayeeNameRequest request);

        [OperationContract]
        Validated<LineItemSearchResult> GetLineItemByPaymentId(GetLineItemByPaymentIdRequest request);

        [OperationContract]
        Validated<LineItemDetailResult> GetLineItemDetails(GetLineItemDetailsRequest request);

        [OperationContract]
        List<AgeingHoldingBalanceSearchResult> GetAgeingHoldingBalances(int age, string officeCode, string processCenterCode, string regionCode, string customerAccount);
    }
}
