using System.ServiceModel;

namespace WUBS.Contracts.Services
{
    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface ISettingsManager
    {
        [OperationContract]
        bool IsCustomerEnabledForApplication(int clientId, int applicationId);

        [OperationContract]
        bool IsCustomerEnabledForProcessorClient(int clientId, int processorClientId);

        [OperationContract]
        bool IsProcessorClientIdExists(int processorClientId);
        
    }
}
