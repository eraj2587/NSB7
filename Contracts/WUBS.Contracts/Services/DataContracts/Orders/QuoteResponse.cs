using System;
using System.Runtime.Serialization;

namespace WUBS.Contracts.Services.DataContracts
{
    [DataContract]
    [KnownType(typeof(RepurchaseQuoteResponse))]
    public class QuoteResponse
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public DateTimeOffset OrderCreatedOn { get; set; }
        [DataMember]
        public DateTimeOffset? RateExpiryTimeStamp { get; set; }
        [DataMember]
        public QuotedLineItem[] LineItems { get; set; }
        [DataMember]
        public QuotedSettlement[] Settlements { get; set; }
        [DataMember]
        public Fee[] Fees { get; set; }
    }

    [DataContract]
    public class RepurchaseQuoteResponse : QuoteResponse
    {
        [DataMember]
        public Money NetWubsProfit { get; set; }

        [DataMember]
        public Money NetCustomerGain { get; set; }
    }

    [DataContract]
    [KnownType(typeof(RepurchaseQuotedLineItem))]
    public class QuotedLineItem
    {
        [DataMember]
        public long LineItemId { get; set; }
        [DataMember]
        public Money Settlement { get; set; }
        [DataMember]
        public Money Trade { get; set; }
        [DataMember]
        public Rate Rate { get; set; }
        [DataMember]
        public Rate InvertedRate { get; set; }
    }

    [DataContract]
    public class RepurchaseQuotedLineItem : QuotedLineItem
    {
        [DataMember]
        public Money WubsProfit { get; set; }

    }


    public class QuotedSettlement
    {
        [DataMember]
        public long SettlementId { get; set; }
        [DataMember]
        public Money Settlement { get; set; }
        [DataMember]
        public SettlementMethod SettlementMethod { get; set; }
    }
}