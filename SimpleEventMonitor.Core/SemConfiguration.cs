using System;
using System.Configuration;

namespace SimpleEventMonitor.Core
{
    public static class SemConfiguration
    {
        private const string HubBaseUrlKey = "SEM:HubBaseUrl";

        public static string HubBaseUrl
        {
            get
            {
                var hubBaseUrl = ConfigurationManager.AppSettings[HubBaseUrlKey];
                if (string.IsNullOrWhiteSpace(hubBaseUrl))
                    throw new ConfigurationErrorsException($"You must provide an AppSetting in your config file called {HubBaseUrlKey} the value must not be empty, and should be the base Url for your monitoring website e.g. http://localhost:2419");
                return hubBaseUrl;
            }
        }
    }
}
