using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.LineItems;

namespace NSB.Contracts.Services.DataContracts.Repurchase
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class QuoteRepurchaseResult
    {
        [DataMember]
        public QuoteRecord QuoteRecord;

        [DataMember]
        public DisplayRate ClientRate;

        [DataMember]
        public Money FXMoney;

        [DataMember]
        public Money ClientRepurchaseMoney;

        [DataMember]
        public Money ClientGainMoney;

        [DataMember]
        public Money NSBRepurchaseCostMoney;

        [DataMember]
        public Money NSBProfitMoney;
    }
}