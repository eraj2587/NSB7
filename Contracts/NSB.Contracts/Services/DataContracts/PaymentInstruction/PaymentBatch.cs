using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class PaymentBatch
    {
        [DataMember]
        public long PaymentBatchId { get; set; }
        [DataMember]
        public int PaymentGateway { get; set; }
        [DataMember]
        public int PaymentFileFormat { get; set; }
        [DataMember]
        public int ClearingType { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public decimal TotalAmount { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public string FileBody { get; set; }
        [DataMember]
        public bool FileBodyStatus { get; set; }
        [DataMember]
        public string FileType { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public bool IsConfirmed { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdatedOn { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public string InternalBankCode { get; set; }
        [DataMember]
        public string StatusMessage { get; set; }
        [DataMember]
        public int DebitAccountId { get; set; }
        [DataMember]
        public int NostroAccountId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int CurrencyId { get; set; }
        [DataMember]
        public string TransferedBy { get; set; }
        [DataMember]
        public string IsArPosted { get; set; }
        [DataMember]
        public string ArPostedBy { get; set; }
        [DataMember]
        public List<PaymentBatchDetail> PaymentBatchDetail { get; set; }
    }
}
