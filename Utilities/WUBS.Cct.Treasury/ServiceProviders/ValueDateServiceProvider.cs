using System;
using System.Configuration;
using System.ServiceModel;
using WUBS.Cct.Treasury.Exceptions;
using WUBS.Cct.Treasury.ServiceProviders.Exceptions;
using WUBS.Cct.Treasury.ServiceProviders.Interfaces;
using WUBS.Cct.Treasury.Service_References.ValueDateWebService;

namespace WUBS.Cct.Treasury.ServiceProviders
{
    public class ValueDateServiceProvider: IValueDateServiceProvider
    {
        private readonly ValueDateServiceSoapClient valueDateWebService;

        private static IValueDateServiceProvider instance;
        public static IValueDateServiceProvider Instance
        {
            get { return instance ?? (instance = new ValueDateServiceProvider()); }
            set { instance = value; }
        }

        private ValueDateServiceProvider()
        {
            valueDateWebService = new ValueDateServiceSoapClient(
                new BasicHttpBinding(),
                new EndpointAddress(new AppSettingsReader().GetValue("ValueDateService.WebServiceURL", typeof(string)).ToString()));
        }

        public DateTime GetPaymentValueDate(int orderDetailId)
        {
            try
            {
                DateTime valueDate, deadLine, cuttOff;

                valueDateWebService.GetPaymentValueDate(orderDetailId, out valueDate, out deadLine, out cuttOff);

                return valueDate;
            }
            catch (FaultException fault)
            {
               throw new UnableToRetrieveValueDateException(string.Format("Unable to get generate value date. {0}", fault.Message));
            }
            catch (CommunicationException ex)
            {
                throw new ValueDateWebServiceUnavailableException(ex);
            }
        }
    }
}
