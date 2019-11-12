using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class Province
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Code { get; set; }  
        
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int CountryId { get; set; }
    }
}
