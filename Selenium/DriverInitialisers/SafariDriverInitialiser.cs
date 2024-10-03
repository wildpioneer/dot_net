using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
using Selenium.Configuration;
using Selenium.Hoster;

namespace Selenium.DriverInitialisers;

public class SafariDriverInitialiser : DriverInitialiser<SafariOptions>
{
    private static readonly Lazy<string?> SafariWebDriverFilePath =
        new Lazy<string?>(() => Environment.GetEnvironmentVariable("SAFARI_WEBDRIVER_FILE_PATH"));

    public SafariDriverInitialiser(ICredentialProvider credentialProvider)
        : base(credentialProvider)
    {
    }

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