﻿using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class Partner
    {
        [DataMember]
        public string Code;
        [DataMember]
        public string Description;
    }
}