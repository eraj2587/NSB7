using System;
using System.Configuration;

namespace WUBS.Cct.Treasury.Infrastructure.Utilities
{
    public static class AppSettingsReadingUtility
    {
        public static T GetValue<T>(string key, T defaultValue)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (value == null)
                return defaultValue;
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
