using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.Orders;

namespace NSB.Contracts.Services.DataContracts
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
