using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Entities
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class Entity
    {
        [DataMember]
        public string Id;

        [DataMember]
        public string Name;

        [DataMember]
        public string Account;
    }
}