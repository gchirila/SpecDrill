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
        public static IElement Create(IBrowser browser, IElement parent, IElementLocator locator)
        {
            return new SeleniumElement(browser, parent, locator);
        }

        public static ISelectElement CreateSelect(IBrowser browser, IElement parent, IElementLocator locator)
        {
            return new SeleniumSelectElement(browser, parent, locator);
        }

        public static INavigationElement<T> CreateNavigation<T>(IBrowser browser, IElement parent, IElementLocator locator)
            where T : class, IPage
        {
            return new SeleniumNavigationElement<T>(browser, parent, locator);
        }
    }
}
