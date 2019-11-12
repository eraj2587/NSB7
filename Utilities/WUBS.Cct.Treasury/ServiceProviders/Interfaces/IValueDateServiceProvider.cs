using System;

namespace WUBS.Cct.Treasury.ServiceProviders.Interfaces
{
    public interface IValueDateServiceProvider
    {
        DateTime GetPaymentValueDate(int orderDetailId);
    }
}