using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.UniformSession;
using WUBS.Contracts.Commands;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Server
{
    public class PaymentReleaseManagerBootstrap : AbstractService, IHandleOneTimeStartupAndShutdown
    {
        //private IEndpointInstance instance;

        //public PaymentReleaseManagerBootstrap(IEndpointInstance _instance)
        //{
        //    instance = _instance;
        //}

        IUniformSession _session;

        public PaymentReleaseManagerBootstrap(IUniformSession session)
        {
            _session = session;
        }

        public Task Startup()
        {
            _session.Send(new CreatePaymentForTestingCommand()).ConfigureAwait(false);
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
