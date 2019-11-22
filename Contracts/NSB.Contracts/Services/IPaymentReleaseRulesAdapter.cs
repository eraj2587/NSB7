using System.Collections.Generic;
using System.ServiceModel;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IPaymentReleaseRulesAdapter
    {
        [OperationContract]
        int GetNostroBankAccountByOpsEssId(int cctOpsESSAccountId);

        [OperationContract]
        Dictionary<int, int> GetAllNostroBankAccountsMapping();
    }
}