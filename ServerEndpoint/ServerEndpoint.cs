using System;
using System.Threading.Tasks;
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

        protected override BaseEndpointConfig EndpointConfig => new ServerEndpointConfig();

        #endregion

        #region Private Methods

        private async static Task Main()
        {

            using (var service = new ServerEndpoint())
            {
                // to run interactive from a console or as a windows service
                if (Environment.UserInteractive)
                {
                    var ad = AppDomain.CurrentDomain;
                    ad.FirstChanceException += (s, ea) => Console.WriteLine($"FirstChanceException {ea.Exception}");
                    ad.UnhandledException += (s, ea) =>  Console.WriteLine($"UnhandledException {ea.ExceptionObject}");

                    Console.Title = "WUBS.Endpoint.Server";
                    var tcs = new TaskCompletionSource<object>();
                    Console.CancelKeyPress += (sender, e) => { e.Cancel = true; tcs.SetResult(null); };

                    await service.OnStartAsync().ConfigureAwait(false);

                    //var endpoint = service.GetEndpoint();
                    //endpoint.SendMessage<CreatePaymentForTestingCommand>(x =>
                    //{
                    //    x.PaymentId = 1234; 
                    //});

                    Console.WriteLine("\r\nPress CTRL+C to stop program\r\n");
                    await tcs.Task.ConfigureAwait(false);
                    await service.OnStopAsync().ConfigureAwait(false);
                    return;
                }
                Run(service);
            }
        }
        #endregion
    }
}
