using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SpecDrill.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Appium;
using SpecDrill.Infrastructure.Enums;
using SpecDrill.SecondaryPorts.AutomationFramework;
//using OpenQA.Selenium.Appium.Android;
//using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.Infrastructure;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.Appium.Enums;

namespace SpecDrill.Adapters.WebDriver
{
    public static class DesiredCapabilitiesExtensions
    {
        private static ILogger Log = Infrastructure.Logging.Log.Get("DesiredCapabilitiesExtensions");
        public static DesiredCapabilities AddCapability(this DesiredCapabilities capabilities, string key, object value, Type enumType = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                Log.Info($"Cannot Add Capability (key is null or whitespace)");
                return capabilities;
            }
            if (value == null)
            {
                Log.Info($"Cannot add capability {key}. Its value is null.");
                return capabilities;
            }

            var stringValue = (string)value;
            if (stringValue != null && string.IsNullOrWhiteSpace(stringValue))
            {
                Log.Info($"Cannot add capability {key}. Its value is empty.");
                return capabilities;
            }

            if (stringValue!= null && enumType != null)
            {
                if (!stringValue.OfEnum(enumType))
                {
                    Log.Info($"Cannot add capability {key}. Its value is not in [{string.Join(", ", Enum.GetNames(enumType))}].");
                    return capabilities;
                }
            }

            capabilities.SetCapability(key, value);
            return capabilities;
        }
    }
    public class SeleniumBrowserFactory : IBrowserDriverFactory
    {

        private static ILogger Log = Infrastructure.Logging.Log.Get<SeleniumBrowserFactory>();
        private readonly Dictionary<BrowserNames, Func<IBrowserDriver>> driverFactory;
        //private readonly Dictionary<BrowserNames>
        private readonly Settings configuration = null;
        public SeleniumBrowserFactory(Settings configuration)
        {
            var aPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Log.Info($"Assembly path = {aPath}");
            this.configuration = configuration;
            driverFactory = new Dictionary<BrowserNames, Func<IBrowserDriver>>
            {
                { BrowserNames.chrome, () =>
                {
                    var bdp = GetBrowserDriversPath(configuration.WebDriver.Browser.Drivers.Chrome.Path);
                    return SeleniumBrowserDriver.Create(new ChromeDriver(bdp, BuildChromeOptions()), this.configuration);
                }},
                { BrowserNames.ie, () =>
                {
                    return SeleniumBrowserDriver.Create(new InternetExplorerDriver(GetBrowserDriversPath(configuration.WebDriver.Browser.Drivers.Ie.Path), BuildInternetExplorerOptions()), this.configuration);
                    } },
                { BrowserNames.firefox, () =>
                    {
                        var binPath = configuration.WebDriver.Browser.Drivers.Firefox.BrowserBinaryPath;
                        var fds = FirefoxDriverService.CreateDefaultService(configuration.WebDriver.Browser.Drivers.Firefox.Path);

                        if (!string.IsNullOrWhiteSpace(binPath))
                        {
                            fds.FirefoxBinaryPath = binPath;
                        }

                        //Environment.SetEnvironmentVariable("webdriver.gecko.driver", configuration.WebDriver.Browser.Drivers.Firefox.Path);
                        return SeleniumBrowserDriver.Create(new FirefoxDriver(fds, BuildFirefoxOptions(), TimeSpan.FromSeconds(60)), this.configuration);
                    } },
                { BrowserNames.opera, () => {
                    return SeleniumBrowserDriver.Create(new OperaDriver(configuration.WebDriver.Browser.Drivers.Opera.Path, BuildOperaOptions()), this.configuration);
                } },
                { BrowserNames.safari, () => SeleniumBrowserDriver.Create(new SafariDriver(configuration.WebDriver.Browser.Drivers.Safari.Path, BuildSafariOptions()), this.configuration) }
            };
        }

        public IBrowserDriver Create(BrowserNames browserName)
        {
            IBrowserDriver result = null;
            var mode = configuration.WebDriver.Mode.ToEnum<Modes>();
            switch (mode)
            {
                case Modes.browser:
                    if (configuration.WebDriver.Browser.IsRemote)
                    {
                        Log.Info($"WebDriver.IsRemote = {configuration.WebDriver.Browser.IsRemote}");
                        switch (browserName)
                        {
                            case BrowserNames.chrome:
                                {
                                    ChromeOptions chromeOptions = BuildChromeOptions();
                                    return CreateRemoteWebDriver(chromeOptions.ToCapabilities());
                                }
                            case BrowserNames.firefox:
                                {
                                    FirefoxOptions firefoxOptions = BuildFirefoxOptions();
                                    return CreateRemoteWebDriver(firefoxOptions.ToCapabilities());
                                }
                            case BrowserNames.opera:
                                {
                                    OperaOptions options = BuildOperaOptions();
                                    return CreateRemoteWebDriver(options.ToCapabilities());
                                }
                            case BrowserNames.safari:
                                {
                                    SafariOptions safariOptions = BuildSafariOptions();
                                    return CreateRemoteWebDriver(safariOptions.ToCapabilities());
                                }
                            case BrowserNames.ie:
                                {
                                    InternetExplorerOptions ieOptions = BuildInternetExplorerOptions();
                                    return CreateRemoteWebDriver(ieOptions.ToCapabilities());
                                }
                            case BrowserNames.edge:
                                {
                                    EdgeOptions edgeOptions = BuildEdgeOptions();
                                    return CreateRemoteWebDriver(edgeOptions.ToCapabilities());
                                }
                            default:
                                throw new ArgumentOutOfRangeException($"SpecDrill: Value Not Supported `{browserName}`!");
                        }
                    }
                    result = driverFactory[browserName]();
                    break;
                case Modes.appium:
                    
                    DesiredCapabilities capabilities = new DesiredCapabilities();
                    
                    capabilities
                        .AddCapability("automationName", configuration.WebDriver.Appium.Capabilities.AutomationName)
                        .AddCapability("platformName", configuration.WebDriver.Appium.Capabilities.PlatformName)
                        .AddCapability("deviceName", configuration.WebDriver.Appium.Capabilities.DeviceName)
                        .AddCapability("browserName", configuration.WebDriver.Appium.Capabilities.BrowserName)
                        .AddCapability("udid", configuration.WebDriver.Appium.Capabilities.UdId)
                        .AddCapability("orientation", configuration.WebDriver.Appium.Capabilities.Orientation, typeof(ScreenOrientations));


                    IWebDriver driver;
                    switch (configuration.WebDriver.Appium.Capabilities.PlatformName.ToEnum<PlatformNames>())
                    {
                        case PlatformNames.Android:
                            driver = new AndroidDriver<AndroidElement>(new Uri(configuration.WebDriver.Appium.ServerUri), capabilities);
                            result = SeleniumBrowserDriver.Create(driver, this.configuration);
                            break;
                        case PlatformNames.iOS:
                            driver = new IOSDriver<AndroidElement>(new Uri(configuration.WebDriver.Appium.ServerUri), capabilities);
                            result = SeleniumBrowserDriver.Create(driver, this.configuration);
                            break;
                        default:
                            driver = new RemoteWebDriver(new Uri(configuration.WebDriver.Appium.ServerUri), capabilities);
                            result = SeleniumBrowserDriver.Create(driver, this.configuration);
                            break;
                    }
                    break;
            }
            return result;
        }

        private static SafariOptions BuildSafariOptions()
        {
            return new SafariOptions();
        }

        private static EdgeOptions BuildEdgeOptions()
        {
            return new EdgeOptions();
        }

        private InternetExplorerOptions BuildInternetExplorerOptions()
        {
            var ieOptions = new InternetExplorerOptions();
            ieOptions.BrowserCommandLineArguments = string.Join(" ", configuration.WebDriver.Browser.Drivers.Ie.Arguments ?? new List<string>());
            ieOptions.ForceCreateProcessApi = !string.IsNullOrWhiteSpace(ieOptions.BrowserCommandLineArguments);
            return ieOptions;
        }

        private OperaOptions BuildOperaOptions()
        {
            var options = new OperaOptions();
            options.AddArguments(configuration.WebDriver.Browser.Drivers.Opera.Arguments ?? new List<string>());
            return options;
        }

        private FirefoxOptions BuildFirefoxOptions()
        {
            var ffOptions = new FirefoxOptions();
            ffOptions.AddArguments(configuration.WebDriver.Browser.Drivers.Firefox.Arguments ?? new List<string>());
            var fp = ffOptions.Profile ?? new FirefoxProfile();
            fp.AcceptUntrustedCertificates = true;
            fp.AssumeUntrustedCertificateIssuer = false;
            ffOptions.Profile = fp;
            var binPath = configuration.WebDriver.Browser.Drivers.Firefox.BrowserBinaryPath;
            if (!string.IsNullOrWhiteSpace(binPath))
            {
                ffOptions.BrowserExecutableLocation = binPath;
            }
            return ffOptions;
        }

        private ChromeOptions BuildChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(configuration.WebDriver.Browser.Drivers.Chrome.Arguments ?? new List<string>());
            chromeOptions.AddArgument($"window-size={configuration.WebDriver.Browser.Window.InitialWidth},{configuration.WebDriver.Browser.Window.InitialHeight}");
            return chromeOptions;
        }

        private string GetBrowserDriversPath(string driverPath)
        {
            if (!driverPath.Contains(":\\"))
            {
                var currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return $"{currentPath}\\{driverPath}";
            }

            return driverPath;
        }

        public IBrowserDriver CreateRemoteWebDriver(ICapabilities desiredCapabilities)
        {
            return SeleniumBrowserDriver.Create(
                            new RemoteWebDriver(
                                new Uri(configuration.WebDriver.Browser.SeleniumServerUri), desiredCapabilities), this.configuration);
        }
    }
}
