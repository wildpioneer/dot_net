﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace Selenium.Core.DriverInitialisers
{
    public static class DriverOptionsHelper
    {
        public static void TryToAddGlobalCapability<T>(this T options, string name, string value) where T : DriverOptions
        {
            switch (options)
            {
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalFirefoxOption(name, value);
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalChromeOption(name, value);
                    break;
                default:
                    options.AddAdditionalOption(name, value);
                    break;
            }
        }

        public static void TryToAddArguments<T>(this T options, string[]? arguments) where T : DriverOptions
        {
            switch (options)
            {
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddArguments(arguments);
                    break;
                case ChromeOptions chromeOptions:
                    chromeOptions.AddArguments(arguments);
                    break;
                case EdgeOptions edgeOptions:
                    edgeOptions.AddAdditionalEdgeOption("args", arguments.ToList());
                    break;
                case InternetExplorerOptions internetExplorerOptions:
                    internetExplorerOptions.AddAdditionalInternetExplorerOption("args", arguments.ToList());
                    break;
                case SafariOptions safariOptions:
                    //safariOptions.AddAdditionalCapability("args", arguments.ToList());
                    break;
                default:
                    throw new NotImplementedException(nameof(TryToAddArguments) + " is not implemented for " +
                                                      options.GetType().Name);
            }
        }
    }
}
