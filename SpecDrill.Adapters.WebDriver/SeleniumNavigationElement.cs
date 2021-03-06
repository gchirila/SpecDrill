﻿using System;
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

        private T Click(ClickType clickType)
        {
            void Click()
            {
                switch (clickType)
                {
                    case ClickType.Double:
                        this.browser.DoubleClick(this); break;
                    case ClickType.Single:
                    default:
                        this.Element.Click(); break;
                }
            }

            Wait.Until(() => this.IsAvailable);
            IPage targetPage = browser.CreatePage<T>();
            Wait.WithRetry().Doing(() => Click()).Until(() => targetPage.IsLoaded);
            targetPage.WaitForSilence();
            return (T)targetPage;
        }
        public T Click() => this.Click(ClickType.Single);

        public T DoubleClick() => this.Click(ClickType.Double);
    }
}
