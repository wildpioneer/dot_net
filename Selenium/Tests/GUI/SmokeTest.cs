using OpenQA.Selenium;

namespace Selenium.Tests.GUI;

public class SmokeTest : BaseTest
{
    [Test]
    public void FirstTest()
    {
        IWebDriver driver = _browserManager.GetDriver();
        driver.Navigate().GoToUrl("https://aqa2705.testrail.io/");
        driver.FindElement(By.Id("name")).SendKeys("atrostyanko@gmail.com");
        driver.FindElement(By.Id("password")).SendKeys("Qwertyu_1");
        driver.FindElement(By.Id("button_primary")).Click();
    }
    
    [Test]
    public void SecondTest()
    {
        IWebDriver driver = _browserManager.GetDriver();
        driver.Navigate().GoToUrl("https://aqa2705.testrail.io/");
        driver.FindElement(By.Id("name")).SendKeys("atrostyanko@gmail.com");
        driver.FindElement(By.Id("password")).SendKeys("Qwertyu_1");
        driver.FindElement(By.Id("button_primary")).Click();
    }

    [Test]
    public void ThirdTest()
    {
        IWebDriver driver = _browserManager.GetDriver();
        driver.Navigate().GoToUrl("https://aqa2705.testrail.io/");
        driver.FindElement(By.Id("name")).SendKeys("atrostyanko@gmail.com");
        driver.FindElement(By.Id("password")).SendKeys("Qwertyu_1");
        driver.FindElement(By.Id("button_primary")).Click();
    }
}