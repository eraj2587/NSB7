using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts
{
    [DataContract]
    public class PaymentResponse
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public string Contact { get; set; }

        [DataMember]
        public DateTime BookingDate { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public List<string> ExternalSystem { get; set; }

        [DataMember]
        public string ExternalSystemReference { get; set; }

        [DataMember]
        public PaymentMethod PaymentMethod { get; set; }

        [DataMember]
        public TradeCurrency trade { get; set; }

        [DataMember]
        public string FundedBy { get; set; }

        [DataMember]
        public DateTime ValueDate { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public string purposeOfPayment { get; set; }

        //payee

        //settlement

        //Fee
    }

    [DataContract]
    public class PaymentsResponse
    {
        [DataMember]
        public List<PaymentResponse> Payments { get; set; }
    }

    [DataContract]
    public class TradeCurrency
    {
        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public string Currency { get; set; }
    }
}
