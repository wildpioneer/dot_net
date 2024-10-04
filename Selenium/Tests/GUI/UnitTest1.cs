using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Core;

namespace Selenium.Tests.GUI;

[Parallelizable(ParallelScope.Children)]
[TestFixture]
public class Tests
{
    private BrowserManagerBack _browserManagerBack;
    private IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        _browserManagerBack = new BrowserManagerBack();
        driver = _browserManagerBack.CurrentBrowser;
    }

    [TearDown]
    public void TearDown()
    {
        //browserDriver.Dispose();
        driver.Quit();
    }
    
    [Test]
    public void Test1()
    {
        _browserManagerBack.CurrentBrowser.Navigate().GoToUrl("https://aqa2705.testrail.io");
        driver.Navigate().GoToUrl("https://aqa2705.testrail.io");
        Assert.Pass();
    }

    [Test]
    public void Test2()
    {
        _browserManagerBack.CurrentBrowser.Navigate().GoToUrl("https://aqa2705.testrail.io");
        driver.Navigate().GoToUrl("https://aqa2705.testrail.io");
        Assert.Pass();
    }

    [Test]
    public void Test3()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://aqa2705.testrail.io");
        Assert.Pass();
        driver.Quit();
    }
}