using NServiceBus;
using System;
using System.Threading.Tasks;
using WUBS.Contracts.Events;

namespace WUBS.Endpoints.Client
{
    public class PaymentCreatedForTestingHandler : IHandleMessages<IPaymentCreatedForTesting>
    {
        public Task Handle(IPaymentCreatedForTesting message, IMessageHandlerContext context)
        {
            Console.WriteLine("Event received with payment id : " + message.PaymentId);
            return Task.CompletedTask;
        }
    }
}
