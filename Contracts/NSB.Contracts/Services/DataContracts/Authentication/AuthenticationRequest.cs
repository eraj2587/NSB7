using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Authentication
{
    [DataContract]
    public abstract class AuthenticationRequest
    {
        [DataMember]
        public int ApplicationId { get; set; }
    }

    [DataContract]
    public class ClientApplicationAuthenticationRequest : AuthenticationRequest
    {
        [DataMember]
        public string CN { get; set; }
        [DataMember]
        public string SN { get; set; }
    }

    [DataContract]
    public class UserAuthenticationRequest : AuthenticationRequest
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    [DataContract]
    public class ServiceAuthenticationRequest : AuthenticationRequest
    {
    }

    [DataContract]
    public class SsoAuthenticationRequest : AuthenticationRequest
    {
        [DataMember]
        public string UserName { get; set; }
    }
}
