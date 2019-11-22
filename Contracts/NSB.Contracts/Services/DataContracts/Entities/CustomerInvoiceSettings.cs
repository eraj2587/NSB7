using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class CustomerInvoiceSettings
    {
        [DataMember]
        public int InvoiceLanguage { get; set; }
        [DataMember]
        public string EntityNameLong { get; set; }
        [DataMember]
        public string EntityShortName { get; set; }
        [DataMember]
        public int LicenseEntity { get; set; }
    }
}
