using Microsoft.Playwright;
using sauceDemo.Base;

namespace TestRail.BaseEntities;

public class BaseTest
{
    protected IPage page;

    [SetUp]
    public async Task Setup()
    {
        PlaywrightDriver playwrightDriver = new PlaywrightDriver();
        page = await playwrightDriver.InitalizePlaywright();
        
        var loginPage = new LoginPage(page);
        
        //var _genericPassword = Environment.GetEnvironmentVariable("PASSWORD");
        //var _standardUser = Environment.GetEnvironmentVariable("USER");
        
        await loginPage.GotoAsync(AnnotationType.Precondition);
        await loginPage.LoginAsync(_standardUser, _genericPassword );
        inventoryPage = new InventoryPage(page);
    }
}
