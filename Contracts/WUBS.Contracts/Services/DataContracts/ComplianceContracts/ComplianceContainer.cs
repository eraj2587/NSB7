using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class ComplianceContainer
    {
        [DataMember]
        [JsonProperty(PropertyName = "messageID")]
        public int MessageId { get; set; }
        [DataMember]
        [JsonProperty(PropertyName = "payment")]
        public CompliancePayment CompliancePayment { get; set; }
    }
}
