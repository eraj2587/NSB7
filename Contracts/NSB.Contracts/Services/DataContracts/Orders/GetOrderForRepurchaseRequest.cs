using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.Orders
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class GetOrderForRepurchaseRequest
    {
        [DataMember]
        public string ConfirmationNumber;
    }
}
