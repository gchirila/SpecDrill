using System;
using OpenQA.Selenium;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill.Adapters.WebDriver
{
    public class SeleniumNavigationElement<T> : SeleniumElement, INavigationElement<T>
        where T: class, IPage
    {
        
        public SeleniumNavigationElement(IBrowser browser, IElement parent, IElementLocator locator) : base(browser, parent, locator)
        {
            this.browser = browser;
            this.locator = locator;
        }

        new public T Click()
        {
            Wait.NoMoreThan(TimeSpan.FromSeconds(30)).Until(() => this.IsAvailable);
            IPage targetPage = browser.CreatePage<T>();
            Wait.WithRetry().Doing(() => this.Element.Click()).Until(() => targetPage.IsPageLoaded);
            return (T) targetPage;
        }

    }
}
