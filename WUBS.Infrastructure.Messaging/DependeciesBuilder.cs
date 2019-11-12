using Autofac;
using Autofac.Integration.Wcf;
using ServiceModelEx;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using NHibernate.SqlCommand;
using WUBS.Infrastructure.Wcf;
using WUBS.Infrastructure.Wcf.Security;

namespace WUBS.Infrastructure.Messaging
{
    internal class DependenciesBuilder
    {
        private readonly Type[] typesPool;

        public DependenciesBuilder(params Type[] typesPool)
        {
            this.typesPool = typesPool;
        }

        public ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();

            //Wire in-process WCF proxies to IOC container
            builder.RegisterTypes(typesPool)
                .Where(t => t.IsSubclassOfRawGeneric(typeof(WcfWrapper<,>)))
                .InstancePerDependency()
                .AsImplementedInterfaces() //register the interface only as the autofac services, not self
                .UseWcfSafeRelease();

            //Wire external facing WCF services to IOC container
            builder.RegisterTypes(typesPool)
                .Where(t => t.HasInterfacesWithAttribute<ServiceContractAttribute>())
                .PropertiesAutowired()
                .InstancePerDependency()
                .PreserveExistingDefaults()
                .AsSelf(); //Register only self as autofac service, not interfaces

           // Wire service hosts to IOC container
            builder.RegisterTypes(typesPool)
                .Where(t => t.IsAssignableTo<IStartableServiceHost>())
                .PropertiesAutowired()
                .SingleInstance()
                .AsClosedTypesOf(typeof(AbstractStartableServiceHost<>))
                .As<IStartableServiceHost>();

            //Wire startup/shutdown handlers
            builder.RegisterTypes(typesPool)
                .Where(t => t.IsAssignableTo<IHandleOneTimeStartupAndShutdown>())
                .PropertiesAutowired()
                .SingleInstance()
                .As<IHandleOneTimeStartupAndShutdown>();

            //Wire error handlers
            builder.RegisterTypes(typesPool)
                .Where(t => t.IsAssignableTo<IHandleErrorsForMessages>())
                .PropertiesAutowired()
                .SingleInstance()
                .As<IHandleErrorsForMessages>();

            builder.RegisterTypes(typesPool)
                .Where(t => t.IsAssignableTo<IScheduledTask>())
                .PropertiesAutowired()
                .AsImplementedInterfaces();

            //Wire service authorizers
            builder.RegisterTypes(typesPool)
                .Where(t => t.IsAssignableTo<IServiceAuthorizer>())
                .PropertiesAutowired()
                .AsImplementedInterfaces();

            //Wire service authenticators
            builder.RegisterTypes(typesPool)
                .Where(t => t.IsAssignableTo<IServiceAuthenticator>())
                .PropertiesAutowired()
                .AsImplementedInterfaces();

            //Wire data contracts to IOC container
            builder.RegisterTypes(typesPool)
                .Where(t => t.HasAttribute<DataContractAttribute>())
                .PropertiesAutowired()
                .InstancePerDependency()
                .PreserveExistingDefaults()
                .AsSelf(); //Register only self as autofac service, not interfaces

            builder.RegisterType<ServiceHostsActivator>()
                .PropertiesAutowired();

            builder.RegisterType<StartupAndShutdownActivator>()
               .PropertiesAutowired();

            return builder;
        }
    }
}
