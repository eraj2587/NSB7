using System;

namespace WUBS.Cct.Treasury.DomainModel.VendorDeals
{
    public class WssVendorPayment
    {
        public long DealNo { get; set; }
        public string VendorName { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public DateTime ValueDate { get; set; }
        public DateTime DealDate { get; set; }
        public int NetFlag { get; set; }
        public int IsTarget { get; set; }        
    }
}
