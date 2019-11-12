using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class PredeliveryBooked : ContractBookedEvent
    {
        [DataMember]
        public long ForwardContractId { get; set; }
    }
}
