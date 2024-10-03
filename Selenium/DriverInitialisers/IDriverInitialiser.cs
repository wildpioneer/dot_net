using OpenQA.Selenium;

namespace Selenium.DriverInitialisers
{
    public interface IDriverInitialiser
    {
        IWebDriver Initialise();
    }
}