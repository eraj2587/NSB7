using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
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
