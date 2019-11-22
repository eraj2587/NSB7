using System;
using System.Runtime.Serialization;

namespace NSB.Contracts.Common.Validation
{
    [DataContract]
    [Serializable] //is required for tests
    public class ValidationFault
    {
        public ValidationFault()
        {
            ErrorDescription = "Validation failed";
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
