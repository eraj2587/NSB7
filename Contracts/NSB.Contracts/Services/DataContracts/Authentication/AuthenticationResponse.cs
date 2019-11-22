using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Authentication
{
    [DataContract(Namespace = "http://schema.business.test.com/contracts/authentication")]
    public abstract class AuthenticationResponse
    {
    }

    [DataContract(Namespace = "http://schema.business.test.com/contracts/authentication")]
    public class UserAuthenticationResponse : AuthenticationResponse
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public Token Token { get; set; }
    }

    [DataContract(Namespace = "http://schema.business.test.com/contracts/authentication")]
    public class ClientApplicationAuthenticationResponse : AuthenticationResponse
    {
        [DataMember]
        public int ApplicationUserId { get; set; }
        [DataMember]
        public Token Token { get; set; }
    }

    [DataContract(Namespace = "http://schema.business.test.com/contracts/authentication")]
    public class ServiceAuthenticationResponse : AuthenticationResponse
    {
        [DataMember]
        public Token Token { get; set; }
    }
}
