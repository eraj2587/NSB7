using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class OffsetForwardContractBooked : ContractBookedEvent
    {
        public bool IsPredeliveryRepoOrFwdSaleRepo { get; set; }
    }
}
