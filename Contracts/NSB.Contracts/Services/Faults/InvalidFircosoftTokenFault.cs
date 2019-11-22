using System.Runtime.Serialization;

namespace NSB.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidFircosoftTokenFault
    {
        public InvalidFircosoftTokenFault() : 
            this ("Invalid or Expired Fircosoft token.")
        {}

        public InvalidFircosoftTokenFault(string error)
        {
            ErrorDescription = error;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
