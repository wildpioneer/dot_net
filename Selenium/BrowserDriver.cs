using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Configuration;
using Selenium.DriverInitialisers;
using Selenium.Hoster;

namespace Selenium
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserDriver : IDisposable
    {
        private readonly IDriverInitialiser _driverInitialiser;

        protected readonly Lazy<IWebDriver> CurrentWebDriverLazy;
        protected bool IsDisposed;

        public BrowserDriver()
        {
            _driverInitialiser = GetDriverInitialiser(SeleniumConfiguration.Browser);
            CurrentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        private IDriverInitialiser GetDriverInitialiser(Browser browser)
        {
            return browser switch
            {
                Browser.Chrome => new ChromeDriverInitialiser(new NoCredentialsProvider()),
                Browser.Firefox => new FirefoxDriverInitialiser(new NoCredentialsProvider()),
                Browser.Edge => new EdgeDriverInitialiser(new NoCredentialsProvider()),
                Browser.Safari => new SafariDriverInitialiser(new NoCredentialsProvider()),
                Browser.InternetExplorer => new InternetExplorerDriverInitialiser(new NoCredentialsProvider()),
                _ => throw new ArgumentException($"Unknown browser {browser}")
            };
        }
        
        /// <summary>
        /// The current Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => CurrentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            return _driverInitialiser.Initialise();
            //return new ChromeDriver();
        }

        /// <summary>
        /// Disposes the Selenium web driver (closing the browser)
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            if (CurrentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            IsDisposed = true;
        }
    }
}