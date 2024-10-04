using Selenium.Core;

namespace Selenium.Tests.GUI;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BaseTest
{
    protected BrowserManager _browserManager;

    [SetUp]
    public void Setup()
    {
        _browserManager = new BrowserManager();
    }

    [TearDown]
    public void TearDown()
    {
        _browserManager.Dispose();
    }
}