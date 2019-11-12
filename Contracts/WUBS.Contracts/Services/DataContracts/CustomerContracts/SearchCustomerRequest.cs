using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CustomerContracts
{
    public class SearchCustomerRequest
    {
        [DataMember] public string CustomerName;
        [DataMember] public string City;
    }
}
