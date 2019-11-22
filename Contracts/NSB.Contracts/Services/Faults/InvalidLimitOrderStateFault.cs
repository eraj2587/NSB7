
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidLimitOrderStateFault
    {
        public InvalidLimitOrderStateFault()
            : this("Invalid Status Fault")
        { }
        public InvalidLimitOrderStateFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
