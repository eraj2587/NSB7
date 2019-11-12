using System;
using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.CurrencyContracts.Pricing;

namespace WUBS.Contracts.Services.DataContracts.CurrencyContracts.Events
{
    [DataContract]
    public class ContractBookedEvent : ContractEvent
    {
        [DataMember]
        public ContractPricingComponent PricingComponent { get; set; }
        [DataMember]
        public DateTime BookingDate { get; set; }
        [DataMember]
        public int BookingPersonId { get; set; }
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int? OptionLeg { get; set; }
        [DataMember]
        public string  OptionContractId { get; set; }

    }
}