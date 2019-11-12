using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    public class PaymentFulfillmentBatch
    {
        [DataMember]
        public long PaymentBatchDetailId { get; set; }
        [DataMember]
        public string PaymentId { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
