using System.Runtime.Serialization;

namespace NSB.Contracts.Services.Faults
{
    [DataContract]
    public class UnableToSendToFircosoftApiFault
    {
        public UnableToSendToFircosoftApiFault() : 
            this ("Unable to send to Fircosoft Api")
        {}

        public UnableToSendToFircosoftApiFault(string error)
        {
            ErrorDescription = error;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
