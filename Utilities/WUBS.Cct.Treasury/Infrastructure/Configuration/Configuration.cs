using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Reflection;

namespace WUBS.Cct.Treasury.Infrastructure.Configuration
{
    public class Configuration
    {
        private static readonly StringDictionary appSettingOverrides = new StringDictionary();

        public static void OverrideAppSettingValue(string key, string newValue)
        {
            appSettingOverrides[key] = newValue;
        }

        public static void ResetAppSettingOverrides()
        {
            appSettingOverrides.Clear();
        }

        private static string GetAppSettingsValue(string key)
        {
            if (appSettingOverrides.ContainsKey(key))
                return appSettingOverrides[key];
            return ConfigurationManager.AppSettings[key];
        }

        public static int GetIntConfigParameter(string name, int defaultValue)
        {
            int value;
            return int.TryParse(GetAppSettingsValue(name), out value) ? value : defaultValue;
        }

        public static int? GetNullableIntConfigParameter(string name)
        {
            int value;
            return int.TryParse(GetAppSettingsValue(name), out value) ? (int?)value : null;
        }

        public static decimal GetDecimalConfigParameter(string name, decimal defaultValue)
        {
            decimal value;
            return decimal.TryParse(GetAppSettingsValue(name), out value) ? value : defaultValue;
        }

        public static string GetStringConfigParameter(string name, string defaultValue)
        {
            string value = GetAppSettingsValue(name);
            return !string.IsNullOrEmpty(value) ? value : defaultValue;
        }

        public static bool GetBoolConfigParameter(string name, bool defaultValue)
        {
            bool value;
            return bool.TryParse(GetAppSettingsValue(name), out value) ? value : defaultValue;
        }

        public static DateTime GetDateTimeConfigParameter(string name, DateTime defaultValue)
        {
            DateTime value;
            return DateTime.TryParse(GetAppSettingsValue(name), out value) ? value : defaultValue;
        }

        public static string GetStringConfigParameter(string name)
        {
            return GetAppSettingsValue(name);
        }

        public static TimeSpan GetTimeSpanConfigParameter(string name, TimeSpan defaultValue)
        {
            TimeSpan value;
            return TimeSpan.TryParse(GetAppSettingsValue(name), out value) ? value : defaultValue;
        }

        public static TimeSpan? GetNullableTimeSpanConfigParameter(string name)
        {
            TimeSpan value;
            return TimeSpan.TryParse(GetAppSettingsValue(name), out value) ? (TimeSpan?)value : null;
        }

        public static string GetConfigFileName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name + ".exe.config";
        }
    }
}
