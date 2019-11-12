using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class ForwardContractBooked : ContractBookedEvent
    {
        [DataMember]
        public bool IsAggregated { get; set; }
    }
}
