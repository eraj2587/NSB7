using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class DrawdownBooked : ContractBookedEvent
    {
        [DataMember]
        public long ForwardContractId { get; set; }
    }
}
