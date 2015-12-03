using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SpecDrill.Configuration;
using SpecDrill.Enums;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;

namespace SpecDrill.Adapters.WebDriver
{
    public class WebDriverBrowser : Browser
    {
        private readonly Dictionary<BrowserNames, Func<string,IWebDriver>> driverFactory = new Dictionary<BrowserNames, Func<string,IWebDriver>>
        {
            { BrowserNames.chrome, bdp => new ChromeDriver(bdp) },
            { BrowserNames.ie, bdp => new InternetExplorerDriver(bdp) },
            { BrowserNames.firefox, bdp => new FirefoxDriver() },
            { BrowserNames.opera, bdp => new OperaDriver() },
            { BrowserNames.safari, bdp => new SafariDriver() }
        };

        private IWebDriver browser;
        public WebDriverBrowser(Settings configuration) : base(configuration)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            var browserName = (BrowserNames) Enum.Parse(typeof (BrowserNames), Configuration.WebDriver.BrowserDriver);

            browser = driverFactory[browserName](Configuration.WebDriver.BrowserDriversPath);
        }
    }
}
