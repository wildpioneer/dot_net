using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Selenium.Configuration;
using Selenium.Hoster;

namespace Selenium.DriverInitialisers;

public class FirefoxDriverInitialiser : DriverInitialiser<FirefoxOptions>
{
    private static readonly Lazy<string?> FirefoxWebDriverFilePath =
        new Lazy<string?>(() => Environment.GetEnvironmentVariable("FIREFOX_WEBDRIVER_FILE_PATH"));

    public FirefoxDriverInitialiser(ICredentialProvider credentialProvider) : base(credentialProvider)
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