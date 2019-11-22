using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Common.Monads;
using NSB.Contracts.Services.DataContracts;
using NSB.Contracts.Services.DataContracts.CustomerContracts;
using NSB.Contracts.Services.DataContracts.Entities;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface ILimitOrderQuery
    {
        [OperationContract]
        Validated<LimitOrderDetailResponse> GetLimitOrder(string id);

        [OperationContract]
        IEnumerable<string> GetSettlementCurrencies();

        [OperationContract]
        IEnumerable<string> GetTradeCurrencies();

        [OperationContract]
        Validated<CustomerAccountInfoSearchResult> GetCustomers(CustomerAccountInfoSearchRequest request);

        [OperationContract]
        Validated<CustomerDetailsResult> GetCustomerDetails(string clientId);

        [OperationContract]
        GetLimitOrderSearchResponse GetLimitOrdersList(LimitOrderSearchRequest request);

        [OperationContract]
        GetLimitOrderSearchResponse GetLimitOrdersListV1(LimitOrderSearchRequest request, bool isApiCall);

        [OperationContract]
        List<LimitOrderSupplierResponse> GetSupplierList();

        [OperationContract]
        Dictionary<int, string> GetCurrencyPairList();

        [OperationContract]
        List<Office> GetOfficeList();

        [OperationContract]
        Validated<LimitOrderDetailResponse> GetLimitOrderV1(string id, bool isApiCall);

        //[OperationContract]
        //GetLimitOrderSearchRefreshResponse GetLimitOrdersListRefresh(LimitOrderSearchRefreshRequest request);

        [OperationContract]
        Validated<GetLimitOrderSearchRefreshResponse> GetLimitOrdersListRefresh(LimitOrderSearchRefreshRequest request);

        [OperationContract]
        Validated<LimitOrderDetailHistoryResponse> GetLimitOrdersHistoryReport(string id);

        [OperationContract]
        Validated<LimitOrderStatisticsReportResponse> GetLimitOrderStatisticsReport(LimitOrderStatisticsReportRequest request);
    }
}
