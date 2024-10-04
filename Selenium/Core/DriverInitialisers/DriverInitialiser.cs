using OpenQA.Selenium;
using Selenium.Core.Configuration;

namespace Selenium.Core.DriverInitialisers;

public abstract class DriverInitialiser<T> : IDriverInitialiser where T : DriverOptions, new()
{
    public IWebDriver Initialise()
    {
        var option = CreateOptions();

        return CreateWebDriver(option);
    }

    private T CreateOptions()
    {
        var options = new T();

        AddDefaultCapabilities(options);

        AddCapabilitiesFromConfiguration(options);

        AddArgumentsFromConfiguration(options);

        return options;
    }

    protected abstract void AddDefaultCapabilities(T options);

    private void AddArgumentsFromConfiguration(T options)
    {
        if (SeleniumConfiguration.Arguments.Any())
        {
            options.TryToAddArguments(SeleniumConfiguration.Arguments);
        }
    }

    private void AddCapabilitiesFromConfiguration(T options)
    {
        if (SeleniumConfiguration.Capabilities.Any())
        {
            foreach (var capability in SeleniumConfiguration.Capabilities)
            {
                options.TryToAddGlobalCapability(capability.Key, capability.Value);
            }
        }
    }

    protected abstract IWebDriver CreateWebDriver(T options);
}