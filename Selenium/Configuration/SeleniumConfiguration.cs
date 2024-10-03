using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Selenium.Configuration
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
        public static Browser Browser => (Browser)Enum.Parse(typeof(Browser), Configuration["selenium:browser"], true);

        /// <summary>
        /// Arguments used to configure the webdriver
        /// </summary>
        public string[] Arguments => new string[] { }; //_specFlowActionsConfiguration.GetArray("selenium:arguments") ?? new string[] { };

        /// <summary>
        /// Capabilities used to configure the webdriver
        /// </summary>
        public Dictionary<string, string> Capabilities => new ();
            //_specFlowActionsConfiguration.GetDictionary("selenium:capabilities");

        /// <summary>
        /// The default timeout used to configure the webdriver
        /// </summary>
        public double? DefaultTimeout => Double.Parse(Configuration["selenium:defaultTimeout"]);

        /// <summary>
        /// The default polling interval used to configure the webdriver
        /// </summary>
        public double? PollingInterval => Double.Parse(Configuration["selenium:pollingInterval"]);
    }
}