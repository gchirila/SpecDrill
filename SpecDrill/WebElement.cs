using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecDrill.Adapters.WebDriver;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill
{
    public class WebElement
    {
        public static IElement Create(IElement parent, IElementLocator locator)
        {
            return new SeleniumElement(Browser.Instance, parent, locator);
        }

        public static ISelectElement CreateSelect(IElement parent, IElementLocator locator)
        {
            return new SeleniumSelectElement(Browser.Instance, parent, locator);
        }

        public static INavigationElement<T> CreateNavigation<T>(IElement parent, IElementLocator locator)
            where T : class, IPage
        {
            return new SeleniumNavigationElement<T>(Browser.Instance, parent, locator);
        }

        public static T CreateControl<T>(IElement parent, IElementLocator elementLocator)
            where T : WebControl
        {

            return Activator.CreateInstance(typeof(T), parent, elementLocator) as T;
        }
    }
}
