using System.Runtime.Serialization;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    [DataContract(Namespace = "http://schemas.business.test.com/2015/10/Opp")]
    public class OrderForRepurchaseLineItem
    {
        [DataMember]
        public int LineItemNumber;
        [DataMember]
        public LineItemType LineItemType;
        [DataMember]
        public decimal SettlementAmount;
        [DataMember]
        public string SettlementCurrencyCode;
        [DataMember]
        public DisplayRate ClientRate;
        [DataMember]
        public decimal FxAmount;
        [DataMember]
        public string FxCurrencyCode;
        [DataMember]
        public Entities.Entity Payee;
        [DataMember]
        public bool IsWorkflowComplete;
        [DataMember]
        public string RepurchaseConfirmationNumber;
        [DataMember]
        public decimal AvailableAmount;
    }
}
