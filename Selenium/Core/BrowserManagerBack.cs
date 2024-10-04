using OpenQA.Selenium;
using Selenium.Core.Configuration;
using Selenium.Core.DriverInitialisers;
using Selenium.Enums;

namespace Selenium.Core
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserManagerBack : IDisposable
    {
        private readonly IDriverInitialiser _driverInitialiser;

        protected readonly Lazy<IWebDriver> CurrentWebDriverLazy;
        protected bool IsDisposed;

        public BrowserManagerBack() : this(SeleniumConfiguration.BrowserType)
        {
        }

        public BrowserManagerBack(BrowserType browserType)
        {
            _driverInitialiser = GetDriverInitialiser(browserType);
            CurrentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }
        
        /// <summary>
        /// The current Selenium IWebDriver instance
        /// </summary>
        public IWebDriver CurrentBrowser => CurrentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            return _driverInitialiser.Initialise();
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
                CurrentBrowser.Quit();
            }

            IsDisposed = true;
        }

        private static readonly Dictionary<BrowserType, Func<IDriverInitialiser>> _browserCreators = new()
        {
            { BrowserType.Chrome, () => new ChromeDriverInitialiser() },
            { BrowserType.Firefox, () => new FirefoxDriverInitialiser() },
            { BrowserType.Edge, () => new EdgeDriverInitialiser() },
            { BrowserType.Safari, () => new SafariDriverInitialiser() }
        };

        private static IDriverInitialiser GetDriverInitialiser(BrowserType browserType)
        {
            if (_browserCreators.TryGetValue(SeleniumConfiguration.BrowserType, out var browserCreator))
            {
                return browserCreator();
            }

            throw new ArgumentException("Неизвестный тип браузера");
        }

        private static IDriverInitialiser GetDriverInitialiser()
        {
            return GetDriverInitialiser(SeleniumConfiguration.BrowserType);
        }
    }
}