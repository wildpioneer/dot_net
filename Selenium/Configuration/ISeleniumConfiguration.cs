namespace Selenium.Configuration
{
    public interface ISeleniumConfiguration
    {
        static Browser Browser { get; }

        string[] Arguments { get; }

        Dictionary<string, string> Capabilities { get; }

        double? DefaultTimeout { get; }

        double? PollingInterval { get; }
    }
}