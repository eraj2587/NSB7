using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
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