using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CustomerContracts
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class CustomerAccountInfoSearchResultItem
    {
        [DataMember]
        public int Id;

        [DataMember]
        public int ProcessCenterId;

        [DataMember]
        public string AccountName;

        [DataMember]
        public string ClientName;

        [DataMember]
        public int OfficeId;

        [DataMember]
        public string State;

        [DataMember]
        public string Province;

        [DataMember]
        public Country Country;

        [DataMember]
        public int DefaultUserId;

        [DataMember]
        public string DefaultUserFirstName;

        [DataMember]
        public string DefaultUserLastName;
    }
}