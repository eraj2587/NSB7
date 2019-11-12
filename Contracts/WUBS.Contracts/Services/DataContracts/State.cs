using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class State
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Code { get; set; }  
        
        [DataMember]
        public string Description { get; set; }
    }
}
