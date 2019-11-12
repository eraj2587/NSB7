using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class DocumentRequest
    {
        [DataMember]
        public CompleteOrder Order { get; set; }
    }

    [DataContract]
    public class RepurchaseDocumentRequest: DocumentRequest
    {
        [DataMember]
        public CompleteOrder OriginalOrder { get; set; }
    }
}