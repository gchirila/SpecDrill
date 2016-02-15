using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill.Adapters.WebDriver.SeleniumExtensions
{
    public static class SeleniumExtensions
    {
        public static ReadOnlyCollection<IElement> ToSpecDrill(this ReadOnlyCollection<object> seleniumWebElements, IBrowser browser, IElementLocator locator)
        {
            var result = new List<IElement>();
            foreach (var seleniumWebElement in seleniumWebElements)
            {
                result.Add(seleniumWebElement.ToSpecDrill(browser, null, locator));
            }
            return new ReadOnlyCollection<IElement>(result);
        }

        public static IElement ToSpecDrill(this object seleniumWebElement, IBrowser browser, IElement parent, IElementLocator locator)
        {
            return new SeleniumElement(browser, null, locator);
        }
    }
}
