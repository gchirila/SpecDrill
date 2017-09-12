using OpenQA.Selenium;
using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium = OpenQA.Selenium;


namespace SpecDrill.Adapters.WebDriver.Extensions
{
    public static class IElementExtensions
    {
        public static IWebElement ToWebElement(this IElement element)
        {
            using (element.Browser.ImplicitTimeout(TimeSpan.FromSeconds(.5d)))
            {
                var webElement = element.NativeElementSearchResult.NativeElement as IWebElement;

                if (webElement == null)
                {
                    throw new Exception($"SpecDrill: Element ({element.Locator}) Not Found!");
                }

                return webElement;
            }
        }
    }
}
