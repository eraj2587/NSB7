using System;
using WUBS.Contracts.Commands;
using WUBS.Infrastructure.Endpoints;
using WUBS.Infrastructure.Messaging.Configurations;

namespace ServerEndpoint
{
    internal class ServerEndpoint : EndpointService
    {
        #region Member Variables and Constants

        #endregion

        #region Protected Methods

        protected override BaseEndpointConfig EndpointConfig
        {
            get { return new ServerEndpointConfig(); }
        }

        #endregion

        #region Private Methods

        private static void Main()
        {
            using (var service = new ServerEndpoint())
            {
                // to run interactive from a console or as a windows service
                if (Environment.UserInteractive)
                {
                    Console.Title = "WUBS.Endpoint.Server";
                    Console.CancelKeyPress += (sender, e) => { service.OnStop(); };
                    service.OnStart(null);

                    //var endpoint = service.GetEndpoint();
                    //endpoint.SendMessage<CreatePaymentForTestingCommand>(x =>
                    //{
                    //    x.PaymentId = 1234; 
                    //});

                    Console.WriteLine("\r\nPress enter key to stop program\r\n");
                    Console.Read();
                    service.OnStop();
                    return;
                }
                Run(service);
            }
        }
        #endregion
    }
}
