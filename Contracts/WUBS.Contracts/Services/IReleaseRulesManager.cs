using System.ServiceModel;
using WUBS.Contracts.Commands;
using WUBS.Contracts.Services.DataContracts.ReleaseRulesContracts;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IReleaseRulesManager
    {
        [OperationContract]
        NostroBankAccountDetailsResponse GetNostroBankAccountDetails(ReleaseRulesDataType releaseRulesDataType,int uniqueRowId);

        [OperationContract]
        UpdatePaymentReleaseRulesCommand GetPaymentReleaseRule(RefreshPaymentReleaseRulesCommand message);
    }
}