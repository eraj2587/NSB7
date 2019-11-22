using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.MassPay
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class Partner
    {
        [DataMember]
        public string Code;
        [DataMember]
        public string Description;
    }
}