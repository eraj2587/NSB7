using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NSB.Infrastructure.Messaging
{
    internal static class TypeEx
    {
        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public static bool HasInterfacesWithAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetInterfaces().Any(i => i.HasAttribute<T>());
        }

        public static bool HasAttribute<T>(this Type type) where T : Attribute
        {
            return type.GetCustomAttributes(typeof(T), false).Any();
        }

        public static IEnumerable<Assembly> GetReferences(this Assembly assembly, params Assembly[] assemblyPool)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            if (assemblyPool == null) throw new ArgumentNullException("assemblyPool");

            var references = assembly.GetReferencedAssemblies().Select(an => Assembly.Load(an.FullName)).Intersect(assemblyPool).ToArray();
            return !references.Any() ? new Assembly[0] : references.Union(references.SelectMany(r => r.GetReferences(assemblyPool)));
        }

        public static IEnumerable<Type> GetReferences(this Type type, bool deepScan, params Type[] typePool)
        {
            if (type == null) throw new ArgumentNullException("type");

            var references = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(member => member.FieldType)
                .Intersect(typePool).ToArray();

            references = references.Union(references.SelectMany(r => typePool.Where(t => r.IsAssignableFrom(t)))).ToArray();

            return deepScan ? references.Union(references.SelectMany(r => r.GetReferences(deepScan, typePool))) : references;
        }

    }
}
