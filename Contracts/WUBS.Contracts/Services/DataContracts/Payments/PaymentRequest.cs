using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{

    [DataContract]
    public class PaymentRequest
    {
        [DataMember(Name = "paymentId")]
        public string PaymentId { get; set; }
    }

    [DataContract]
    public class PaymentsRequest
    {
        [DataMember(Name = "paymentIds")]
        public List<string> PaymentIds { get; set; }
    }

    [DataContract]
    public class PaymentGeneralDetailsRequest
    {
        [DataMember(Name = "paymentId")]
        public string PaymentId { get; set; }

        [DataMember(Name = "externalOrderReference")]
        public int ExternalOrderReference { get; set; }

        [DataMember(Name = "externalSystemReference")]
        public string ExternalSystemReference { get; set; }
    }

}
