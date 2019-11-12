using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    [KnownType(typeof(RepurchaseQuoteRequest))]
    public class QuoteRequest
    {
        [DataMember]
        public string OrderId { get; set; }
    }

    [DataContract]
    public class RepurchaseQuoteRequest : QuoteRequest
    {
        [DataMember]
        public QuoteType QuoteType { get; set; }
    }
}
