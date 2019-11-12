using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class UnableToGetCostPricingSpreadWhenQuotingFault
    {
        public UnableToGetCostPricingSpreadWhenQuotingFault()
            : this("Unable to Quote Order Fault")
        { }

        public UnableToGetCostPricingSpreadWhenQuotingFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
