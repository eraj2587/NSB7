﻿using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Authentication
{
    [DataContract]
    public class TokenAuthorizationCredentials
    {
        [DataMember]
        public string TokenUrl { get; set; }
        [DataMember]
        public string ClientId { get; set; }
        [DataMember]
        public string ClientSecret { get; set; }
    }
}
