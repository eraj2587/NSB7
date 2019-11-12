using System.Collections.Generic;
using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts;
using WUBS.Contracts.Services.DataContracts.MassPay;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IReferenceDataQuery
    {
        [OperationContract]
        CurrencyResult GetCurrencies();

        [OperationContract]
        List<ProcessCenter> GetProcessingCenters();

        [OperationContract]
        List<Office> GetOffices();

        [OperationContract]
        List<Region> GetRegions();
    }
}
