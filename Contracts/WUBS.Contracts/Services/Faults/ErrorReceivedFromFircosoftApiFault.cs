using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class ErrorReceivedFromFircosoftApiFault
    {
        public ErrorReceivedFromFircosoftApiFault() :
            this("Fircosoft API returned error.")
        { }

        public ErrorReceivedFromFircosoftApiFault(string error)
        {
            ErrorDescription = error;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
