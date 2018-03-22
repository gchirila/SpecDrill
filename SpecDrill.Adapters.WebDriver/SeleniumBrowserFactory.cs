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

        public static bool ValidateCapability(string key, object value, Type enumType = null)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                Log.Info($"Cannot Add Capability (key is null or whitespace)");
                return false;
            }
            if (value == null)
            {
                Log.Info($"Cannot add capability {key}. Its value is null.");
                return false;
            }

            var stringValue = (string)value;
            if (stringValue != null && string.IsNullOrWhiteSpace(stringValue))
            {
                Log.Info($"Cannot add capability {key}. Its value is empty.");
                return false;
            }

            if (stringValue != null && enumType != null)
            {
                if (!stringValue.OfEnum(enumType))
                {
                    Log.Info($"Cannot add capability {key}. Its value is not in [{string.Join(", ", Enum.GetNames(enumType))}].");
                    return false;
                }
            }
            return true;
        }
        public static DesiredCapabilities AddCapability(this DesiredCapabilities capabilities, string key, object value, Type enumType = null)
        {
            if (ValidateCapability(key, value, enumType))
            {
                capabilities.SetCapability(key, value);
            }
            return capabilities;
        }

        public static DriverOptions AddCapability(this DriverOptions driverOptions, string key, object value, Type enumType = null)
        {
            if (ValidateCapability(key, value, enumType))
            {
                driverOptions.AddAdditionalCapability(key, value);
            }
            return driverOptions;
        }
    }
    public class SeleniumBrowserFactory : IBrowserDriverFactory
    {
        private static ILogger Log = Infrastructure.Logging.Log.Get<SeleniumBrowserFactory>();
        private readonly Dictionary<BrowserNames, Func<IBrowserDriver>> driverFactory;

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
                { BrowserNames.edge, () =>
                {
                    return SeleniumBrowserDriver.Create(new EdgeDriver(GetBrowserDriversPath(configuration.WebDriver.Browser.Drivers.Edge.Path), BuildEdgeOptions()), this.configuration);
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
                                    OperaOptions operaOptions = BuildOperaOptions();
                                    return CreateRemoteWebDriver(operaOptions.ToCapabilities());
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
                    ExtendCapabilities((k,v) => capabilities.AddCapability(k, v), 
                        configuration.WebDriver.Appium.Capabilities);

                    IWebDriver driver;
                    var configCapabilities = configuration.WebDriver.Appium.Capabilities;
                    const string PLATFORM_NAME = "platformName";
                    EnsureCapabilityIsConfigured(configCapabilities, PLATFORM_NAME);

                    switch (configuration.WebDriver.Appium.Capabilities[PLATFORM_NAME].ToString().ToEnum<PlatformNames>())
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

        #region Capabilities Utility Methods
        private void EnsureCapabilityIsConfigured(Dictionary<string, object> configCapabilities, string CAPABILITY_NAME)
        {
            if (!configCapabilities.ContainsKey(CAPABILITY_NAME) || configCapabilities[CAPABILITY_NAME] == null || string.IsNullOrEmpty(configCapabilities[CAPABILITY_NAME].ToString()))
                throw new MissingMemberException($"SpecDrill: Value Not Present `{CAPABILITY_NAME}`!");
        }

        private void ExtendCapabilities(Action<string, object> addCapability, Dictionary<string, object> configuredCapabilities)
        {
            foreach (var kvp in configuredCapabilities)
            {
                try
                {
                    addCapability(kvp.Key, kvp.Value);
                }
                catch (ArgumentException)
                {
                    Log.Info($"Key {kvp.Key} already exists. Dropping version with value {kvp.Value}");
                }
                catch (Exception)
                {
                    Log.Info($"Error adding Key {kvp.Key} with value {kvp.Value}");
                }
            }
        }
        #endregion

        #region Option Builders
        private SafariOptions BuildSafariOptions()
        {
            var safariOptions = new SafariOptions();
            ExtendCapabilities((key, value) => safariOptions.AddCapability(key, value),
                                        configuration.WebDriver.Browser.Capabilities);
            return safariOptions;
        }

        private EdgeOptions BuildEdgeOptions()
        {
            var edgeOptions = new EdgeOptions();
            var edgeCommandLineArguments = configuration.WebDriver.Browser.Drivers.Edge.Arguments;
            if (edgeCommandLineArguments != null && edgeCommandLineArguments.Count > 0)
            {
                Log.Warning($"Specified command line argument(s) for Edge were igonred !");
            }
            edgeOptions.AcceptInsecureCertificates = true;
            ExtendCapabilities((key, value) => edgeOptions.AddCapability(key, value),
                                        configuration.WebDriver.Browser.Capabilities);
            return edgeOptions;
        }

        private InternetExplorerOptions BuildInternetExplorerOptions()
        {
            var ieOptions = new InternetExplorerOptions();
            ieOptions.BrowserCommandLineArguments = string.Join(" ", configuration.WebDriver.Browser.Drivers.Ie.Arguments ?? new List<string>());
            ieOptions.ForceCreateProcessApi = !string.IsNullOrWhiteSpace(ieOptions.BrowserCommandLineArguments);
            ieOptions.AcceptInsecureCertificates = true;
            ExtendCapabilities((key, value) => ieOptions.AddCapability(key, value),
                                        configuration.WebDriver.Browser.Capabilities);
            return ieOptions;
        }

        private OperaOptions BuildOperaOptions()
        {
            var options = new OperaOptions();
            options.AddArguments(configuration.WebDriver.Browser.Drivers.Opera.Arguments ?? new List<string>());
            ExtendCapabilities((key, value) => options.AddCapability(key, value),
                                        configuration.WebDriver.Browser.Capabilities);
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
            ExtendCapabilities((key, value) => ffOptions.AddCapability(key, value),
                                        configuration.WebDriver.Browser.Capabilities);
            return ffOptions;
        }

        private ChromeOptions BuildChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(configuration.WebDriver.Browser.Drivers.Chrome.Arguments ?? new List<string>());
            chromeOptions.AddArgument($"window-size={configuration.WebDriver.Browser.Window.InitialWidth},{configuration.WebDriver.Browser.Window.InitialHeight}");
            ExtendCapabilities((key, value) => chromeOptions.AddCapability(key, value),
                                        configuration.WebDriver.Browser.Capabilities);
            return chromeOptions;
        }
        #endregion
    }
}
