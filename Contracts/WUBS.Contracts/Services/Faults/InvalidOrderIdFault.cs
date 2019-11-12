using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidOrderIdFault
    {
        [DataMember]
        public string OrderId { get; internal set; }

        public InvalidOrderIdFault(string orderId)
        {
            OrderId = orderId;
        }
    }
}
