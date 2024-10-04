using OpenQA.Selenium;
using Selenium.Core.Configuration;
using Selenium.Core.DriverInitialisers;
using Selenium.Enums;

namespace Selenium.Core;

public class BrowserManager : IDisposable
{
    private ThreadLocal<IWebDriver> _browserDriver = new ();
    protected bool IsDisposed;
    
    public IWebDriver GetDriver()
    {
        return GetDriver(SeleniumConfiguration.BrowserType);
    }

    public IWebDriver GetDriver(BrowserType browserType)
    {
        return _browserDriver.Value ?? (_browserDriver.Value = CreateWebDriver(browserType));
    }
    
    /// <summary>
    /// Creates the Selenium web driver (opens a browser)
    /// </summary>
    /// <returns></returns>
    private IWebDriver CreateWebDriver(BrowserType browserType)
    {
        return GetDriverInitialiser(browserType).Initialise();
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

        if (_browserDriver.IsValueCreated)
        {
            GetDriver().Quit();
        }

        IsDisposed = true;
    }

    
    private static readonly Dictionary<BrowserType, Func<IDriverInitialiser>> BrowserCreators = new()
    {
        { BrowserType.Chrome, () => new ChromeDriverInitialiser() },
        { BrowserType.Firefox, () => new FirefoxDriverInitialiser() },
        { BrowserType.Edge, () => new EdgeDriverInitialiser() },
        { BrowserType.Safari, () => new SafariDriverInitialiser() }
    };

    private static IDriverInitialiser GetDriverInitialiser(BrowserType browserType)
    {
        if (BrowserCreators.TryGetValue(SeleniumConfiguration.BrowserType, out var browserCreator))
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