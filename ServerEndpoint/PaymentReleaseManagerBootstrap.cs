﻿using System.Threading.Tasks;
using NServiceBus;
using WUBS.Contracts.Commands;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Server
{
    public class PaymentReleaseManagerBootstrap : AbstractService, IHandleOneTimeStartupAndShutdown
    {
        private IEndpointInstance instance;

        public PaymentReleaseManagerBootstrap(IEndpointInstance _instance)
        {
            instance = _instance;
        }

        public Task Startup()
        {
           // instance.Send(new CreatePaymentForTestingCommand()).ConfigureAwait(false);
            //Set release schedules
           // Bus.SendLocal(new StartPaymentReleaseSaga { TaskName = "ReleasePaymentSaga" });
            return Task.CompletedTask;
        }

        public Task Shutdown()
        {
            return Task.CompletedTask;
        }
    }
}
