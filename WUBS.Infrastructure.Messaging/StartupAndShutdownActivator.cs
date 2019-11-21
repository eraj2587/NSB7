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
        public IContainer Container { get; set; }

        private async Task InvokeStartup()
        {
            if (Handlers != null && Handlers.Any())
            {
                foreach (var handler in Handlers)
                   await handler.Startup();
            }
        }

        private async Task InvokeShutdown()
        {
            if (Handlers != null && Handlers.Any())
            {
                foreach (var handler in Handlers)
                   await handler.Shutdown();
            }
        }

        public async Task Start()
        {
            Handlers = Container.Resolve<IHandleOneTimeStartupAndShutdown[]>();
            await InvokeStartup();
        }

        public async Task Stop()
        {
            await InvokeShutdown();
        }

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }

        //public void Run(Configure config)
        //{
        //    if (config.Settings.Get<bool>("Endpoint.SendOnly")) Start();
        //}
    }
}

