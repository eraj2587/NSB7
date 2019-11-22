using NServiceBus;
using NServiceBus.Hosting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Workflow.Common.Messages;
using NSB.Contracts.Events;

namespace NSB.Infrastructure.Messaging
{
    public class TypeScanner
    {

        private readonly Type[] scannedTypes;
        private readonly Dictionary<Type, EndpointAttribute> typesWithEndpointConfiguration;

        public TypeScanner(params Assembly[] assembliesToScan)
        {
            if (assembliesToScan == null || !assembliesToScan.Any())
                assembliesToScan = new AssemblyScanner().GetScannableAssemblies().Assemblies.ToArray();

            scannedTypes = assembliesToScan.SelectMany(a => a.GetTypes()).Where(t => !t.IsClass || !t.IsAbstract).Distinct().ToArray();
            typesWithEndpointConfiguration = scannedTypes.Select(
                t => new { type = t, attr = GetCustomEndpointAttribute(t) })
                .Where(t => t.attr != null)
                .ToDictionary(k => k.type, v => v.attr);
        }

        private EndpointAttribute GetCustomEndpointAttribute(Type t)
        {
            return Attribute.GetCustomAttribute(t, typeof(EndpointAttribute)) as EndpointAttribute;
        }

        public Type[] GetAllScannedTypes()
        {
            return scannedTypes;
        }

        public IEnumerable<Tuple<Type, string>> GetAllTypesWithPublishingEndpoints()
        {
            return typesWithEndpointConfiguration.Select(kv => Tuple.Create(kv.Key, kv.Value.PublishingEndpointName));
        }

        public static bool IsMessage(Type type)
        {
            return type.IsClass && !type.IsAbstract && type.Namespace != null &&
                (type.Namespace.StartsWith("NSB.Contracts") || WorkflowMessageTypes.IsCommandType(type));
        }

        public static bool IsCommand(Type type)
        {
            return type.IsClass && !type.IsAbstract && type.Namespace != null && (type.Namespace.StartsWith("NSB.Managers.Internal") || type.Namespace.StartsWith("NSB.Contracts.Commands"));
        }

        public static bool IsEvent(Type type)
        {
            return (!type.IsClass && type.Namespace != null && (type.Namespace.StartsWith("NSB.Contracts.Events")) || (type.Namespace != null &&
               type.Namespace.StartsWith("ServiceControl.Contracts")) || typeof(IEvent).IsAssignableFrom(type));
        }

    }
}
