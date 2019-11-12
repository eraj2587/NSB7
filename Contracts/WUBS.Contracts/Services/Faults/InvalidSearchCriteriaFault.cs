using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidSearchCriteriaFault
    {
        public InvalidSearchCriteriaFault() : this("Invalid Search Criteria Fault")
        { }
        public InvalidSearchCriteriaFault(string description)
        {
            ErrorDescription = description;
        }
        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
