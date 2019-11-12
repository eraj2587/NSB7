using NServiceBus;
using System;
using System.Threading.Tasks;
using WUBS.Contracts.Commands;
using WUBS.Contracts.Events;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Client
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
