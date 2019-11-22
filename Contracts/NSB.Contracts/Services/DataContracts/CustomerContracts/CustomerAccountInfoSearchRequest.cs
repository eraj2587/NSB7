using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CustomerContracts
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class CustomerAccountInfoSearchRequest
    {
        [DataMember] public string AccountName;
        [DataMember] public int UserId;
        [DataMember] public int MaxResults;
        [DataMember] public Application Application;
        [DataMember] public string NeededSettingCode;
    }
}
