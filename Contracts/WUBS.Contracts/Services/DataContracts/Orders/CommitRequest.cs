using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class CommitRequest
    {
        [DataMember]
        public string OrderId { get; set; }
    }
}
