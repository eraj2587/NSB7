using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class CommitRequest
    {
        [DataMember]
        public string OrderId { get; set; }
    }
}
