using System.ServiceModel;
using WUBS.Contracts.Services.DataContracts.ComplianceContracts;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IComplianceQuery
    {
        [OperationContract]
        ComplianceQueryResponse GetRequestByOrderDetailId(int orderDetailId);
    }
}