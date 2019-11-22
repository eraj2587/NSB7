using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Entities
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class CustomerDetailsResult
    {
        [DataMember] public string Id;

        [DataMember] public string FullName;

        [DataMember] public string Account;

        [DataMember] public Address Address;

        [DataMember] public string Email;

        [DataMember] public string Phone;

        [DataMember] public string ResponsibleUser;

        [DataMember] public string DefaultUser;

        [DataMember] public string Vertical;

        [DataMember] public string Office;

        [DataMember] public string ProcessingCenter;

        [DataMember] public List<User> CustomerUsers;

        [DataMember] public bool IsActive;

        [DataMember] public string SettlementCurrency;
    }
}