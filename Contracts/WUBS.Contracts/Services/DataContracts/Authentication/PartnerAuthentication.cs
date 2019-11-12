using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Authentication
{
    [DataContract]
    public class PartnerAuthentication
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string PartnerCN { get; set; }

        [DataMember]
        public string PartnerSN { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
