using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.PaymentInstruction
{
    [DataContract]
    public class PaymentBatchIdFilter
    {
        [DataMember]
        public DateTime BeginDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public bool IsOutgoing { get; set; }
        [DataMember]
        public int CurrencyId { get; set; }
        [DataMember]
        public int StatusId { get; set; }
    }
}