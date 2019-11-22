using System.Runtime.Serialization;
using NSB.Contracts.Services.DataContracts.Entities;
using NSB.Contracts.Services.DataContracts.Orders;

namespace NSB.Contracts.Services.DataContracts.LineItems
{
    public class LineItemDetailResultItem : LineItem
    {
        [DataMember]
        public CustomerDetailsResult Payer;
        [DataMember]
        public string SettlementCurrencyCode;
        [DataMember]
        public decimal SettlementAmount;
        [DataMember]
        public DisplayRate ClientRate;
        [DataMember]
        public CustomerDetailsResult Payee;
        [DataMember]
        public string PaymentPurpose;
        [DataMember]
        public string PaymentReference;
        [DataMember]
        public string Notes;
        [DataMember]
        public LineItemStatus LineItemStatus;
        [DataMember]
        public string BookedBy;
    }
}
