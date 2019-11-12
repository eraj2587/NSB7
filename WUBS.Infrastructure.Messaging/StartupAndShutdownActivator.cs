using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WUBS.Infrastructure.Messaging
{
    internal class StartupAndShutdownActivator : IDisposable
    {
        public IEnumerable<IHandleOneTimeStartupAndShutdown> Handlers { get; set; }
        public IContainer Container { get; set; }

        private void InvokeStartup()
        {
            if (Handlers != null && Handlers.Any())
            {
                foreach (var handler in Handlers)
                    handler.Startup();
            }
        }

        private void InvokeShutdown()
        {
            if (Handlers != null && Handlers.Any())
            {
                foreach (var handler in Handlers)
                    handler.Shutdown();
            }
        }

        public void Start()
        {
            Handlers = Container.Resolve<IHandleOneTimeStartupAndShutdown[]>();
            InvokeStartup();
        }

        public void Stop()
        {
            InvokeShutdown();
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

