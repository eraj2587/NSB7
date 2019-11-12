using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class BuildResponse
    {
        [DataMember]
        public string OrderId { get; set; }
    }
}
