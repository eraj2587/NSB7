using System;

namespace WUBS.Cct.Treasury.DomainModel.VendorDeals
{
    public class WssFxTrade
    {
        public int UserId { get; set; }
        public string RefNumber { get; set; }
        public string RelatedRefNumber { get; set; }
        public int? DealType { get; set; }
        public int ItemType { get; set; }
        public string BuyCcy { get; set; }
        public string SellCcy { get; set; }
        public decimal BuyAmount { get; set; }
        public decimal SellAmount { get; set; }
        public decimal TradeRate { get; set; }
        public string CustNo { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public int MultDiv { get; set; }
        public int Status { get; set; }
        public string StatusMsg { get; set; }
    }
}
