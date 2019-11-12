using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts.SalesForceOAuth2
{
    [DataContract]
    public class SFCaseResponseList
    {
        [DataMember]
        public List<PaymentsResponse> PaymentsResponse { get; set; }

        public SFCaseResponseList()
        {
            PaymentsResponse = new List<PaymentsResponse>();
        }
    }
    [DataContract]
    public class PaymentsResponse
    {
        [DataMember]
        public string ClientID { get; set; }
        [DataMember]
        public string StatusCode { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string PaymentID { get; set; }
        [DataMember]
        public string FailureReason { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
    }
}