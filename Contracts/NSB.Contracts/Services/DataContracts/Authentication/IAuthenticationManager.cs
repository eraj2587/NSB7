using System.ServiceModel;

namespace NSB.Contracts.Services.DataContracts.Authentication
{
    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/authentication")]
    public interface IAuthenticationManager
    {
        [OperationContract]
        [ServiceKnownType(typeof(UserAuthenticationRequest))]
        [ServiceKnownType(typeof(SsoAuthenticationRequest))]
        [ServiceKnownType(typeof(ClientApplicationAuthenticationRequest))]
        [ServiceKnownType(typeof(ServiceAuthenticationRequest))]
        [ServiceKnownType(typeof(UserAuthenticationResponse))]
        [ServiceKnownType(typeof(ClientApplicationAuthenticationResponse))]
        [ServiceKnownType(typeof(ServiceAuthenticationResponse))]
        AuthenticationResponse Authenticate(AuthenticationRequest request);
    }
}
