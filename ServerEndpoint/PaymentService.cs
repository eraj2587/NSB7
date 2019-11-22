using System;
using System.Configuration;
using NSB.Infrastructure.Wcf;

namespace NSB.Endpoints.Server
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
