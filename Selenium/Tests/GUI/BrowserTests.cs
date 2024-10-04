using OpenQA.Selenium;
using Selenium.Core;
using Selenium.Enums;

namespace Selenium.Tests.GUI;

[TestFixture]
[Parallelizable(ParallelScope.Children)]  // Указание уровня параллельности
public class BrowserTests
{
    [Test]
    [TestCase(BrowserType.Chrome)]
    [TestCase(BrowserType.Firefox)]
    public void TestBrowserInitialization(BrowserType browserType)
    {
        BrowserManagerBack managerBack = new BrowserManagerBack(browserType);
        IWebDriver driver = managerBack.CurrentBrowser;

        driver.Navigate().GoToUrl("https://www.google.com");

        Assert.AreEqual("Google", driver.Title);

        // Завершаем работу драйвера после теста
        managerBack.Dispose();
    }
}