using WUBS.Cct.Treasury.DomainModel.VendorDeals;

namespace WUBS.Cct.Treasury.Mappers.Interfaces
{
    public interface IWssVendorPaymentMapper
    {
        void InsertVendorPayment(WssVendorPayment deal);
    }
}
