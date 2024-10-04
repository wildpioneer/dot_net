using Selenium.Enums;

namespace Selenium.Core.Configuration
{
    public interface ISeleniumConfiguration
    {
        static BrowserType BrowserType { get; }

        static string[]? Arguments { get; }

        static Dictionary<string, string> Capabilities { get; }

        static double? DefaultTimeout { get; }

        static double? PollingInterval { get; }
    }
}