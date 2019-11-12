using System.Collections.Concurrent;
using System.Configuration;

namespace WUBS.Cct.Treasury.Infrastructure.Persistence
{
    internal static class AppConfigDatabaseConnectionStrings
    {
        private static ConcurrentDictionary<string, string> cachedDbConnectionStrings = new ConcurrentDictionary<string, string>();

        private static string GetCachedDbConnectionString(string key)
        {
            string value;
            if (!cachedDbConnectionStrings.TryGetValue(key, out value))
                value = cachedDbConnectionStrings.GetOrAdd(key, new AppSettingsReader().GetValue(key, typeof(string)).ToString());
            return value;
        }

        public static string RueschLink
        {
            get { return GetCachedDbConnectionString("ConnectionString.Rueschlink"); }
        }

        public static string CRS
        {
            get { return GetCachedDbConnectionString("ConnectionString.Crs"); }
        }

        public static string History
        {
            get { return GetCachedDbConnectionString("ConnectionString.History"); }
        }

        public static string Vmars
        {
            get { return GetCachedDbConnectionString("ConnectionString.Vmars"); }
        }

        public static string Vms
        {
            get { return GetCachedDbConnectionString("ConnectionString.VMS"); }
        }

        public static string NostroSubsidiary
        {
            get { return GetCachedDbConnectionString("ConnectionString.NostroSubsidiary"); }
        }
    }
}
