using System.ServiceModel;
using NSB.Contracts.Commands;
using NSB.Contracts.Services.DataContracts.ReleaseRulesContracts;

namespace NSB.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IReleaseRulesManager
    {
        [OperationContract]
        NostroBankAccountDetailsResponse GetNostroBankAccountDetails(ReleaseRulesDataType releaseRulesDataType,int uniqueRowId);

        [OperationContract]
        UpdatePaymentReleaseRulesCommand GetPaymentReleaseRule(RefreshPaymentReleaseRulesCommand message);
    }
}