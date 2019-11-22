using NServiceBus.Logging;
using ServiceModelEx;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace NSB.Infrastructure.Wcf
{
    public class ErrorHandler : IErrorHandler
    {

        private readonly ILog logger;

        public ErrorHandler(ILog logger)
        {
            this.logger = logger;
        }


        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            ErrorHandlerHelper.PromoteException(error, version, ref fault);
        }

        public bool HandleError(Exception error)
        {
            logger.Error(string.Format("WCF server fault: {0}", error));
            return false;
        }
    }

    public class ErrorHandlerServiceBehaviour : IServiceBehavior
    {

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {

        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
            BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase host)
        {
            foreach (var dispatcher in host.ChannelDispatchers.Cast<ChannelDispatcher>())
            {
                dispatcher.ErrorHandlers.Add(new ErrorHandler(LogManager.GetLogger(host.Description.Name)));
            }

        }
    }
}