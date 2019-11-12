using System;
using System.Configuration;
using WUBS.Infrastructure.Wcf;

namespace WUBS.Endpoints.Server
{
    public class PaymentsService : AbstractStartableServiceHost<PaymentManager>
    {
        public PaymentsService() : base(new[] { BaseAddress }) { }
        private static Uri BaseAddress
        {
            get { return new Uri(ConfigurationManager.AppSettings["Endpoint.PaymentsService.Uri"]); }
        }
    }
}
