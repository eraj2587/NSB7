using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class OfficeInvoiceDetails
    {
        [DataMember]
        public int OfficeId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string MailingAddress { get; set; }
        [DataMember]
        public string EmailFrom { get; set; }
        [DataMember]
        public string EmailReplyTo { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string TollFreeNumber { get; set; }
        [DataMember]
        public string FaxNumber { get; set; }
        [DataMember]
        public int CountryId { get; set; }
        [DataMember]
        public string MainOfficeFaxNumber { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public int StatusId { get; set; }
    }
}
