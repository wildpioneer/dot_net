using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Core.DriverInitialisers
{
    public class ChromeDriverInitialiser : DriverInitialiser<ChromeOptions>
    {
        private static readonly Lazy<string?> ChromeWebDriverFilePath =
            new(() => Environment.GetEnvironmentVariable("CHROME_WEBDRIVER_FILE_PATH"));

        protected override void AddDefaultCapabilities(ChromeOptions options)
        {
        }

        protected override IWebDriver CreateWebDriver(ChromeOptions options)
        {
            return string.IsNullOrWhiteSpace(ChromeWebDriverFilePath.Value)
                ? new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(120))
                : new ChromeDriver(ChromeDriverService.CreateDefaultService(ChromeWebDriverFilePath.Value), options,
                    TimeSpan.FromSeconds(120));
        }
    }
}