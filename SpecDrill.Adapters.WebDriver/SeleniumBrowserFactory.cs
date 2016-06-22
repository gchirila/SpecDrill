using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SpecDrill.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using SpecDrill.Infrastructure.Enums;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SpecDrill.Adapters.WebDriver
{
    public class SeleniumBrowserFactory : IBrowserDriverFactory
    {
        private readonly Dictionary<BrowserNames, Func<string,IBrowserDriver>> driverFactory = new Dictionary<BrowserNames, Func<string,IBrowserDriver>>
        {
            { BrowserNames.chrome, bdp =>
            //TODO: extract window parameters in specDrillConfig.json
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("window-size=1920,1080");
                return SeleniumBrowserDriver.Create(new ChromeDriver(bdp, chromeOptions));
            }},
            { BrowserNames.ie, bdp => SeleniumBrowserDriver.Create(new InternetExplorerDriver(bdp)) },
            { BrowserNames.firefox, bdp => SeleniumBrowserDriver.Create(new FirefoxDriver()) },
            { BrowserNames.opera, bdp => SeleniumBrowserDriver.Create(new OperaDriver()) },
            { BrowserNames.safari, bdp => SeleniumBrowserDriver.Create(new SafariDriver()) }
        };

        private readonly Settings configuration = null;
        public SeleniumBrowserFactory(Settings configuration)
        {
            this.configuration = configuration;
        }
        
        public IBrowserDriver Create(BrowserNames browserName)
        {
            return driverFactory[browserName](configuration.WebDriver.BrowserDriversPath);
        }
    }
}
