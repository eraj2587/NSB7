using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Entities
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/NSB")]
    public class CustomerUsersResult
    {
        [DataMember] public int DefaultUserId;
        [DataMember] public List<User> CustomerUsers;
    }
}