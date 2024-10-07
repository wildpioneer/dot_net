using Microsoft.Playwright;

namespace sauceDemo.Components;

public class BaseLocator
{
    protected ILocator Locator { get; set; }
    protected IPage Page { get; }

    public BaseLocator(IPage page, string locator)
    {
        Locator = page.Locator(locator);
        Page = page;
    }
}
