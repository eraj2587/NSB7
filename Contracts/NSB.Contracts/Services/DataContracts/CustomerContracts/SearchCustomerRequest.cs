using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CustomerContracts
{
    public class SearchCustomerRequest
    {
        [DataMember] public string CustomerName;
        [DataMember] public string City;
    }
}
