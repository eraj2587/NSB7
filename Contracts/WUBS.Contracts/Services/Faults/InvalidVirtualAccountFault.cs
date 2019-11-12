using System.Runtime.Serialization;


namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidVirtualAccountFault
    {
        public InvalidVirtualAccountFault()
            : this("Invalid Virtual Account Fault")
        { }

        public InvalidVirtualAccountFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
