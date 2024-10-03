using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Configuration;
using Selenium.DriverInitialisers;
using Selenium.Hoster;

namespace Selenium;

[Parallelizable(ParallelScope.All)]
[TestFixture]
public class Tests
{
    private BrowserDriver browserDriver;
    private BrowserInteractions browserInteractions;
    
    [SetUp]
    public void Setup()
    {
        browserDriver = new BrowserDriver();
        browserInteractions = new BrowserInteractions(browserDriver);
    }

    [TearDown]
    public void TearDown()
    {
        browserDriver.Dispose();
    }
    
    [Test]
    public void Test1()
    {
        browserDriver.Current.Navigate().GoToUrl("https://www.google.com");
        Assert.Pass();
    }

    [Test]
    public void Test2()
    {
        browserDriver.Current.Navigate().GoToUrl("https://aqa2705.testrail.io");
        Assert.Pass();
    }

    [Test]
    public void Test3()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://aqa2705.testrail.io");
        Assert.Pass();
    }
}