using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Selenium.Core.DriverInitialisers;

public class FirefoxDriverInitialiser : DriverInitialiser<FirefoxOptions>
{
    private static readonly Lazy<string?> FirefoxWebDriverFilePath =
        new Lazy<string?>(() => Environment.GetEnvironmentVariable("FIREFOX_WEBDRIVER_FILE_PATH"));

    public FirefoxDriverInitialiser() : base()
    {
    }

    protected override void AddDefaultCapabilities(FirefoxOptions options)
    {
        
    }

    protected override IWebDriver CreateWebDriver(FirefoxOptions options)
    {
        return string.IsNullOrWhiteSpace(FirefoxWebDriverFilePath.Value)
            ? new FirefoxDriver(FirefoxDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(120))
            : new FirefoxDriver(FirefoxDriverService.CreateDefaultService(FirefoxWebDriverFilePath.Value), options,
                TimeSpan.FromSeconds(120));
    }
}