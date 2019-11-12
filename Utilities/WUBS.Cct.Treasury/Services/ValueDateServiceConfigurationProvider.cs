using System;
using System.Collections.Generic;
using System.Configuration;

namespace WUBS.Cct.Treasury.Services
{
    public class ValueDateServiceConfigurationProvider : IValueDateServiceConfigurationProvider
    {
        public Dictionary<string, int> CurrencySpotDays { get; private set; }
        private const string SpotDaysPrefix = "NonStd.SPOT.";

        public ValueDateServiceConfigurationProvider()
        {
            CurrencySpotDays = GetCurrencySpotDays();
        }

        private static Dictionary<string, int> GetCurrencySpotDays()
        {
            var ccySpotDays = new Dictionary<string, int>();

            foreach (var key in ConfigurationManager.AppSettings.AllKeys)
            {
                if (key.StartsWith(SpotDaysPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    var value = ConfigurationManager.AppSettings[key];

                    if (!string.IsNullOrEmpty(value))
                    {
                        var ccyCode = key.Substring(SpotDaysPrefix.Length);
                        var spotDays = Convert.ToInt32(value);

                        ccySpotDays.Add(ccyCode, spotDays);
                    }
                }
            }

            return ccySpotDays;
        }
    }

    public interface IValueDateServiceConfigurationProvider
    {
        Dictionary<string, int> CurrencySpotDays { get; }
    }
}