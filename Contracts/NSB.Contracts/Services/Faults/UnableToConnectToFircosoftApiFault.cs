using System.Runtime.Serialization;

namespace NSB.Contracts.Services.Faults
{
    [DataContract]
    public class UnableToConnectToFircosoftApiFault
    {
        public UnableToConnectToFircosoftApiFault() : 
            this ("Unable to connect to Fircosoft Api")
        {}

        public UnableToConnectToFircosoftApiFault(string error)
        {
            ErrorDescription = error;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
