using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class CustomerNotEligibleFault
    {
        public CustomerNotEligibleFault()
            : this("Customer Not Eligible For Holding Fault")
        { }

        public CustomerNotEligibleFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
