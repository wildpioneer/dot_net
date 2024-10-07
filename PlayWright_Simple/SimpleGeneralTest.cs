using Microsoft.Playwright;

namespace PlayWright_Simple;

public class SimpleGeneralTest : PageTest
{
    [Test]
    public async Task FirstSimpleTest()
    {
        await Page.GotoAsync("https://aqa2705.testrail.io/");

        // Button
        //  by Text
        await Page.ClickAsync("text='Log In'");

        //  by Role
        var loginButton = Page.GetByRole(AriaRole.Button, new()
        {
            NameRegex = new Regex("Log In")
        });

        // Input
        Expect(Page.GetByTestId("loginIdName")).ToBeEditableAsync();
        Expect(Page.Locator("data-testid=loginIdName")).ToBeEditableAsync();
        Expect(Page.Locator("#name")).ToBeEditableAsync();
        Expect(Page.Locator("[name='name']")).ToBeEditableAsync();
        Expect(Page.Locator("//*[@name='name']")).ToBeEditableAsync();
        
        await Page.GetByTestId("loginIdName").FillAsync("atrostyanko@gmail.com");

        // Label
        Expect(Page.Locator("label:has-text('Password')")).ToBeVisibleAsync();
        
        await Page.GetByTestId("loginPasswordFormDialog").FillAsync("Qwertyu_1");

        await loginButton.ClickAsync();
    }
}