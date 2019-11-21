using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WUBS.Infrastructure.Messaging
{
    internal class StartupAndShutdownActivator : IDisposable
    {
        public IEnumerable<IHandleOneTimeStartupAndShutdown> Handlers { get; set; }

        public StartupAndShutdownActivator(IHandleOneTimeStartupAndShutdown[] handlers)
        {
            Handlers = handlers;
        }

        private async Task InvokeStartup()
        {
            if (Handlers != null && Handlers.Any())
            {
                foreach (var handler in Handlers)
                    await handler.Startup().ConfigureAwait(false);
            }
        }

        private async Task InvokeShutdown()
        {
            if (Handlers != null && Handlers.Any())
            {
                foreach (var handler in Handlers)
                    await handler.Shutdown().ConfigureAwait(false);
            }
        }

        public async Task Start()
        {
            await InvokeStartup().ConfigureAwait(false);
        }

        public async Task Stop()
        {
            await InvokeShutdown().ConfigureAwait(false);
            Handlers = null;
        }

        public void Dispose()
        {
            if (Handlers == null) throw new InvalidOperationException("Stop is not called");
            GC.SuppressFinalize(this);
        }

        //public void Run(Configure config)
        //{
        //    if (config.Settings.Get<bool>("Endpoint.SendOnly")) Start();
        //}
    }
}

