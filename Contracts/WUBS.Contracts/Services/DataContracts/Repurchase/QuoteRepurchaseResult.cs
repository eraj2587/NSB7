using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.LineItems;

namespace WUBS.Contracts.Services.DataContracts.Repurchase
{
    [DataContract(Namespace = "http://schemas.business.westernunion.com/2015/10/Opp")]
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
        public Money WubsRepurchaseCostMoney;

        [DataMember]
        public Money WubsProfitMoney;
    }
}