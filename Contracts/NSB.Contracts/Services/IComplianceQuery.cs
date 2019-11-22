using System.ServiceModel;
using NSB.Contracts.Services.DataContracts.ComplianceContracts;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IComplianceQuery
    {
        [OperationContract]
        ComplianceQueryResponse GetRequestByOrderDetailId(int orderDetailId);
    }
}