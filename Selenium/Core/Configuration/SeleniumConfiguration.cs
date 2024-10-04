using System.Collections;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Selenium.Enums;

namespace Selenium.Core.Configuration
{
    public class SeleniumConfiguration : ISeleniumConfiguration
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;

        /// <summary>
        /// Provides the configuration details for the webdriver instance
        /// </summary>
        /// <param name="specFlowActionJsonLoader"></param>
        static SeleniumConfiguration()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("selenium.actions.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "selenium.actions.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }

        /// <summary>
        /// The browser specified in the configuration
        /// </summary>
        public static BrowserType BrowserType =>
            (BrowserType)Enum.Parse(typeof(BrowserType), Configuration["selenium:browser"], true);

        /// <summary>
        /// Arguments used to configure the webdriver
        /// </summary>
        public static string[]? Arguments
        {
            get
            {
                var argumentsList = new ArrayList();
                IConfigurationSection arguments = Configuration.GetSection("selenium:arguments");
                foreach (IConfigurationSection child in arguments.GetChildren())
                {
                    argumentsList.Add(child.Value);
                }

                return (string[])argumentsList.ToArray(typeof(string));
            }
        }

        /// <summary>
        /// Capabilities used to configure the webdriver
        /// </summary>
        public static Dictionary<string, string> Capabilities
        {
            get
            {
                var capabilitiesMap = new Dictionary<string, string>();
                IConfigurationSection capabilities = Configuration.GetSection("selenium:capabilities");
                
                foreach (IConfigurationSection child in capabilities.GetChildren())
                {
                    capabilitiesMap.Add(child.Key, child.Value);
                }

                return capabilitiesMap;
            }
        }

        /// <summary>
        /// The default timeout used to configure the webdriver
        /// </summary>
        public static double? DefaultTimeout => Double.Parse(Configuration["selenium:defaultTimeout"]);

        /// <summary>
        /// The default polling interval used to configure the webdriver
        /// </summary>
        public static double? PollingInterval => Double.Parse(Configuration["selenium:pollingInterval"]);
    }
}