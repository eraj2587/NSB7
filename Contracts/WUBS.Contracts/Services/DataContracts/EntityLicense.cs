using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class EntityLicense
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string LicenseNo { get; set; }
    }
}
