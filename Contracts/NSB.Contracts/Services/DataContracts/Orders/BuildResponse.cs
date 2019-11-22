using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class BuildResponse
    {
        [DataMember]
        public string OrderId { get; set; }
    }
}
