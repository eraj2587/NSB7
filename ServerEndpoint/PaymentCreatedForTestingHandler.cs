using NServiceBus;
using System;
using System.Threading.Tasks;
using NSB.Contracts.Events;

namespace NSB.Endpoints.Client
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
