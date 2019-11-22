using System;
using System.Collections.Generic;

namespace NSB.Contracts.Common.Errors
{
    /// <summary>
    /// Dictionary assigned to class name for readability.
    /// </summary>
    internal static class ResourceManagerCache
    {

        static Dictionary<Type, ResourceInfo> s_Cache = new Dictionary<Type, ResourceInfo>();

        internal static ResourceInfo ResourceInfoForType(Type type)
        {
            ResourceInfo returnValue;
            if (!s_Cache.TryGetValue(type, out returnValue))
            {
                returnValue = new ResourceInfo(type);
                s_Cache.Add(type, returnValue);
            }

            return returnValue;
        }
    }
}
