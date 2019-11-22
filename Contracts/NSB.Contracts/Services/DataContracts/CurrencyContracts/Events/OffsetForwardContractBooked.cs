using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class OffsetForwardContractBooked : ContractBookedEvent
    {
        public bool IsPredeliveryRepoOrFwdSaleRepo { get; set; }
    }
}
