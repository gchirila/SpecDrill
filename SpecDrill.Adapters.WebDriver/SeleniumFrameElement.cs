using System;
using OpenQA.Selenium;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill.Adapters.WebDriver
{
    public class SeleniumFrameElement<T> : SeleniumElement, IFrameElement<T>
        where T: class, IPage
    {
        
        public SeleniumFrameElement(IBrowser browser, IElement parent, IElementLocator locator) : base(browser, parent, locator)
        {
            this.browser = browser;
            this.locator = locator;
        }

        public T SwitchTo()
        {
            Wait.NoMoreThan(TimeSpan.FromSeconds(30)).Until(() => this.IsAvailable);
            Browser.SwitchToFrame(this);
            IPage targetPage = browser.CreatePage<T>();
            Wait.Until(() => targetPage.IsLoaded);
            targetPage.WaitForSilence();
            return (T) targetPage;
        }
    }
}
