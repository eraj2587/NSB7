﻿using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public enum PaymentSourceType : byte
    {
        [EnumMember]
        LineItem = 1,
        [EnumMember]
        Settlement = 2,
        [EnumMember]
        Payment = 3
    }
}
