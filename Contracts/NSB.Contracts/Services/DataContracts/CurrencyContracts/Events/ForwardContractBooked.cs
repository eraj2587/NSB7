using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class ForwardContractBooked : ContractBookedEvent
    {
        [DataMember]
        public bool IsAggregated { get; set; }
    }
}
