using System.Runtime.Serialization;

namespace NSB.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidCustomerFault
    {
        public InvalidCustomerFault()
            : this("Invalid Customer Fault")
        { }

        public InvalidCustomerFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
