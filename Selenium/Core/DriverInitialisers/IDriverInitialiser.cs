using OpenQA.Selenium;

namespace Selenium.Core.DriverInitialisers
{
    public interface IDriverInitialiser
    {
        IWebDriver Initialise();
    }
}