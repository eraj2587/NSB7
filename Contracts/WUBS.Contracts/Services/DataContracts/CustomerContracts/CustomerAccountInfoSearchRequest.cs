using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CustomerContracts
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class CustomerAccountInfoSearchRequest
    {
        [DataMember] public string AccountName;
        [DataMember] public int UserId;
        [DataMember] public int MaxResults;
        [DataMember] public Application Application;
        [DataMember] public string NeededSettingCode;
    }
}
