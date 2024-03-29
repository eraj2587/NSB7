﻿using System.ServiceModel;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.UniformSession;
using NSB.Contracts.Commands;
using NSB.Infrastructure.Messaging;

namespace NSB.Endpoints.Server
{
    public class PaymentManager : AbstractService, IPaymentManager
    {
        //IEndpointInstance _instance;

       IUniformSession _session;

        //public PaymentManager(IEndpointInstance instance)
        //{
        //    _instance = instance;
        //}

        public PaymentManager(IUniformSession session)
        {
            _session = session;
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public async Task<string> Foo()
        {
            await _session.Send<CreatePaymentForTestingCommand>(x => { x.PaymentId = 123; }).ConfigureAwait(false);
            Logger.Info("CreatePaymentForTestingCommand send for value 123");
            return "bar";
        }
    }

    [ServiceContract(Namespace = "http://schema.business.test.com/contracts/")]
    public interface IPaymentManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Task<string> Foo();
    }
}