using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using WUBS.Infrastructure.Messaging;
using WUBS.Infrastructure.Messaging.Messages;

namespace WUBS.Endpoints.Server
{
    class PaymentReleaseBootstrap
    {
        public class PaymentReleaseManagerBootstrap :  IHandleOneTimeStartupAndShutdown
        {
            private IEndpointInstance instance;
            public Task Startup()
            {
                //Set release schedules
                return
                    instance.SendLocal(new BeginScheduledTask
                    {
                        TaskTypeFullName = "test",
                        WaitDuration = TimeSpan.FromSeconds(10)
                    });
                //  Bus.SendLocal(new StartPaymentReleaseSaga { TaskName = "ReleasePaymentSaga" });
            }

            public Task Shutdown()
            {
                return Task.CompletedTask;
            }
        }
    }
}
