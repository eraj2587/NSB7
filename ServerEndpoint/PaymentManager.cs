using System.ServiceModel;
using NServiceBus;
using WUBS.Contracts.Commands;
using WUBS.Infrastructure.Messaging;

namespace WUBS.Endpoints.Server
{
    public class PaymentManager : AbstractService, IPaymentManager
    {
        private IEndpointInstance _instance;

        public PaymentManager(IEndpointInstance instance)
        {
            _instance = instance;
        }


        [OperationBehavior(TransactionScopeRequired = true)]
        public string Foo()
        {
            _instance.SendCommand<CreatePaymentForTestingCommand>(x => { x.PaymentId = 123; });
            Logger.Info("CreatePaymentForTestingCommand send for value 123");
            return "bar";
        }
    }

    [ServiceContract(Namespace = "http://schema.business.westernunion.com/contracts/")]
    public interface IPaymentManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string Foo();
    }
}