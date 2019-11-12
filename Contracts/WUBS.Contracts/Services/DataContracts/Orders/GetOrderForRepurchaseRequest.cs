using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.Orders
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
    public class GetOrderForRepurchaseRequest
    {
        [DataMember]
        public string ConfirmationNumber;
    }
}
