using ServiceModelEx;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WUBS.Infrastructure.Wcf
{
    public abstract class AbstractClientBase<T> : ContextClientBase<T> where T : class
    {

        protected AbstractClientBase(Binding binding, EndpointAddress remoteAddress)
            : base(Guid.NewGuid(), binding, remoteAddress)
        {
            this.AddGenericResolver();
        }

    }
}
