﻿using System;
using WUBS.Infrastructure.Endpoints;
using WUBS.Infrastructure.Messaging.Configurations;

namespace ClientEndpoint
{
    internal class ClientEndpoint : EndpointService
    {
        #region Member Variables and Constants

        #endregion

        #region Protected Methods

        protected override BaseEndpointConfig EndpointConfig
        {
            get { return new ClientEndpointConfig(); }
        }

        #endregion

        #region Private Methods

        private static void Main()
        {
            using (var service = new ClientEndpoint())
            {
                // to run interactive from a console or as a windows service
                if (Environment.UserInteractive)
                {
                    var ad = AppDomain.CurrentDomain;
                    ad.FirstChanceException += (s, ea) => Console.WriteLine($"FirstChanceException {ea.Exception}");
                    ad.UnhandledException += (s, ea) =>  Console.WriteLine($"UnhandledException {ea.ExceptionObject}");

                    Console.Title = "WUBS.Endpoint.Client";
                    Console.CancelKeyPress += (sender, e) => { service.OnStop(); };
                    service.OnStart(null);

                    //var endpoint=service.GetEndpoint();
                    //endpoint.PublishMessage<IPaymentCreatedForTesting>(msg =>
                    //{
                    //    msg.PaymentId = 1234;
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
