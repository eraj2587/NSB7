using System.Collections.Generic;
using System.ServiceModel;
using NSB.Contracts.Services.DataContracts;
using NSB.Contracts.Services.DataContracts.MassPay;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
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
