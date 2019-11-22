using NServiceBus;
using System;
using System.Threading.Tasks;
using NSB.Contracts.Commands;
using NSB.Contracts.Events;
using NSB.Infrastructure.Messaging;

namespace NSB.Endpoints.Client
{
    public class CreatePaymentForTestingCommandHandler : AbstractService, IHandleMessages<CreatePaymentForTestingCommand>
    {
        public async Task Handle(CreatePaymentForTestingCommand message, IMessageHandlerContext context)
        {
            Logger.Info("Command received with payment id : " + message.PaymentId);
            await context.Publish<IPaymentCreatedForTesting>(x => { x.PaymentId = message.PaymentId; });
            Logger.Info("Published event with payment id : " + message.PaymentId);
        }
    }
}
