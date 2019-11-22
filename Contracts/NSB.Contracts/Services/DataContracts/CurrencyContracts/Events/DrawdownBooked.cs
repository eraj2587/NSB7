using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class DrawdownBooked : ContractBookedEvent
    {
        [DataMember]
        public long ForwardContractId { get; set; }
    }
}
