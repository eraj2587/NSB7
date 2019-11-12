using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class UnableToQuoteFault
    {
        public UnableToQuoteFault()
            : this("Unable to Quote Order Fault")
        { }

        public UnableToQuoteFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
