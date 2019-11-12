using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Authentication
{
    [DataContract]
    public class TokenAuthorizationCache
    {
        [DataMember]
        public string AccessToken { get; set; }
        [DataMember]
        public string TokenType { get; set; }
        [DataMember]
        public DateTimeOffset? ExpiresOn { get; set; }
    }
}
