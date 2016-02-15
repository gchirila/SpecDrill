using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecDrill.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecDrill.Infrastructure.Configuration;

namespace SpecDrill.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ShouldHaveCorrectValuesWhenReadingJsonConfigurationFile()
        {
            var configuration = ConfigurationManager.Load(JsonConfigurationFileContents);
            Assert.IsNotNull(configuration);
            Assert.IsNotNull(configuration.WebDriver);
            Assert.AreEqual("chrome", configuration.WebDriver.BrowserDriver);
            Assert.AreEqual(12345, configuration.MaxWait);
            Assert.AreEqual(1, configuration.Homepages.Length);
            Assert.AreEqual("Test000LoginPage", configuration.Homepages[0].PageObjectType);
        }

        private static string JsonConfigurationFileContents
        {
            get
            {
                return @"{ 
                                ""webdriver"": {
                                    ""browserDriver"" :  ""chrome"", // chrome, ie, firefox, opera
                                    ""browserDriversPath"": ""d:\\_specDrill\\drivers""
                                },
                                ""maxWait"": ""12345"",
                                ""waitPollingFrequency"" : ""200"",
                                ""homepages"": 
                                [
                                    {
                                            ""pageObjectType"": ""Test000LoginPage"",
                                            ""url"": ""file:///D:/_cloud/Dropbox/Projects/SpecDrill/SpecDrill/SomeTests/WebsiteMocks/Test000/login.html""
                                    }
                                ]
                         }";
            }
        }
    }
}
