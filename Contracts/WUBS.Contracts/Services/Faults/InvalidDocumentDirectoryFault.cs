using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.Faults
{
    [DataContract]
    public class InvalidDocumentDirectoryFault
    {
        public InvalidDocumentDirectoryFault()
            : this("Document directory is not accessible or invalid")
        { }

        public InvalidDocumentDirectoryFault(string description)
        {
            ErrorDescription = description;
        }

        [DataMember]
        public string ErrorDescription { get; internal set; }
    }
}
