using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.UniformSession;
using WUBS.Contracts.Commands;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Server
{
    public class PaymentReleaseManagerBootstrap : AbstractService, IHandleOneTimeStartupAndShutdown
    {
        private IUniformSession session;

        public PaymentReleaseManagerBootstrap(IUniformSession session)
        {
            this.session = session;
        }

        public async Task Startup()
        {
            await session.Send(new CreatePaymentForTestingCommand()).ConfigureAwait(false);
            //Set release schedules
            // Bus.SendLocal(new StartPaymentReleaseSaga { TaskName = "ReleasePaymentSaga" });
        }

        public Task Shutdown()
        {
            return Task.CompletedTask;
        }
    }
}
