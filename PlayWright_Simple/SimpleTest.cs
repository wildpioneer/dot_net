using Microsoft.Playwright;

namespace PlayWright_Simple;

public class SimpleTest
{
    [Test]
    public async Task FirstSimpleTest()
    {
        // Создаем новый instance Playwright
        using var playwright = await Playwright.CreateAsync();

        // Создаем новый instance of Browser
        await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = false
            }
        );

        // Создаем Context
        await using var context = await browser.NewContextAsync();

        // Создаем Page
        var page = await context.NewPageAsync();

        await page.GotoAsync("https://aqa2706.testrail.io/");

        // Button
        //  by Text
        await page.ClickAsync("text='Log In'");

        //  by Role
        var loginButton = page.GetByRole(AriaRole.Button, new()
        {
            NameRegex = new Regex("Log In")
        });

        // Input
        var loginByTestId = page.GetByTestId("loginIdName");
        var isLoginEditable = await loginByTestId.IsEditableAsync();
        Assert.IsTrue(isLoginEditable);

        var loginById = page.Locator("#name");
        isLoginEditable = await loginById.IsEditableAsync();
        Assert.IsTrue(isLoginEditable);

        var loginByCss = page.Locator("[name='name']");
        isLoginEditable = await loginByCss.IsEditableAsync();
        Assert.IsTrue(isLoginEditable);

        var loginByXPath = page.Locator("//*[@name='name']");
        isLoginEditable = await loginByXPath.IsEditableAsync();
        Assert.IsTrue(isLoginEditable);

        await loginByTestId.FillAsync("atrostyanko@gmail.com");

        // Label
        var labelByCss = page.Locator("label:has-text('Password')");
        var isLabelVisible = await labelByCss.IsVisibleAsync();
        Assert.IsTrue(isLabelVisible);

        await page.GetByTestId("loginPasswordFormDialog").FillAsync("Qwertyu_1");

        var waitResponse = page.WaitForResponseAsync("**/dashboard");
        
        await loginButton.ClickAsync();

        var getResponse = await waitResponse;
        
        Console.WriteLine(getResponse);

        //await page.Locator(".button-ok").Locator("visible=true").ClickAsync();
        
        /*
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "log-in1.png"
        });
        */

    }
}