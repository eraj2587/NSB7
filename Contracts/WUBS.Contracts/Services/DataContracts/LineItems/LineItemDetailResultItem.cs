using System.Runtime.Serialization;
using WUBS.Contracts.Services.DataContracts.Entities;
using WUBS.Contracts.Services.DataContracts.Orders;

namespace WUBS.Contracts.Services.DataContracts.LineItems
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
