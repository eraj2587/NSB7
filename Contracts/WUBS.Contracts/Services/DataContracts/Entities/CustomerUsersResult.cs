using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Entities
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/WUBS")]
    public class CustomerUsersResult
    {
        [DataMember] public int DefaultUserId;
        [DataMember] public List<User> CustomerUsers;
    }
}