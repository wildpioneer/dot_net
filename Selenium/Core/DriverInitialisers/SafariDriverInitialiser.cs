using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace Selenium.Core.DriverInitialisers;

public class SafariDriverInitialiser : DriverInitialiser<SafariOptions>
{
    private static readonly Lazy<string?> SafariWebDriverFilePath =
        new(() => Environment.GetEnvironmentVariable("SAFARI_WEBDRIVER_FILE_PATH"));

    protected override void AddDefaultCapabilities(SafariOptions options)
    {
        
    }

    protected override IWebDriver CreateWebDriver(SafariOptions options)
    {
        return string.IsNullOrWhiteSpace(SafariWebDriverFilePath.Value)
            ? new SafariDriver(SafariDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(120))
            : new SafariDriver(SafariDriverService.CreateDefaultService(SafariWebDriverFilePath.Value), options,
                TimeSpan.FromSeconds(120));
    }
}