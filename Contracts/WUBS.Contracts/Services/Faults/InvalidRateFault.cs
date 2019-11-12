using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidRateFault
    {
        public InvalidRateFault()
            : this("Unable to retrieve the rate")
        { }

        public InvalidRateFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
