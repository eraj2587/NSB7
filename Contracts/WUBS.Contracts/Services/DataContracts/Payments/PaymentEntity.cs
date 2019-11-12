using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{

    [DataContract]
    public class PaymentEntity
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string PublicId { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public string Creator { get; set; }
        [DataMember]
        public byte EntityType { get; set; }
    }
}
