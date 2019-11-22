using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts.LineItems;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
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
