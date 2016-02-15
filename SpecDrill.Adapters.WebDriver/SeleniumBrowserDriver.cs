using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecDrill.Adapters.WebDriver.ElementLocatorExtensions;
using SpecDrill.Adapters.WebDriver.SeleniumExtensions;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SpecDrill.Adapters.WebDriver
{
    internal class SeleniumBrowserDriver : IBrowserDriver
    {
        private IWebDriver seleniumDriver = null;

        #region JavaScript Functions
        // dispatches event on specified dom element;
        // e.g. dispatch(document.getElementById('someId'), 
        private readonly string sdDispatch =
            @"var sdDispatch = function(el, evName) { var ev = document.createEvent('Event'); ev.initEvent(evName, true, false); el.dispatchEvent(ev);};";
        #endregion

        public SeleniumBrowserDriver(IWebDriver seleniumDriver)
        {
            this.seleniumDriver = seleniumDriver;
        }

        public static IBrowserDriver Create(IWebDriver seleniumDriver)
        {
            return new SeleniumBrowserDriver(seleniumDriver);
        }

        public void GoToUrl(string url)
        {
            seleniumDriver.Navigate().GoToUrl(url);
        }

        public void Exit()
        {
            seleniumDriver.Quit();
        }

        public string Title
        {
            get { return seleniumDriver.Title; }
            set { }

        }

        public void ChangeBrowserDriverTimeout(TimeSpan timeout)
        {
            this.seleniumDriver.Manage().Timeouts().ImplicitlyWait(timeout);
        }

        public ReadOnlyCollection<object> FindElements(IElementLocator locator)
        {
            var result = new List<object>();
            var elements = seleniumDriver.FindElements(locator.ToSelenium());
            result.AddRange(elements);
            return new ReadOnlyCollection<object>(result);
        }

        public object FindElement(IElementLocator locator)
        {
            var elements = seleniumDriver.FindElements(locator.ToSelenium());
            if (elements == null || elements.Count == 0)
                return null;
            return elements[0];
        }

        public object ExecuteJavaScript(string js, params object[] arguments)
        {
            var javaScriptExecutor = (seleniumDriver as IJavaScriptExecutor);

            if (javaScriptExecutor == null)
            {
                //TODO: Log reason
                return false;
            }

            try
            {
                return javaScriptExecutor.ExecuteScript(js, arguments);
            }
            catch (Exception e)
            {
                //TODO :log exception
                return false;
            }
        }

        public void MoveToElement(IElement element)
        {
            //ExecuteJavaScript(string.Format(@"{0} sdDispatch(arguments[0],'mouseover');", sdDispatch), (element as SeleniumElement).Element);
            var actions = new Actions(this.seleniumDriver);
            actions.MoveToElement((element as SeleniumElement).Element);
            actions.Perform();
        }
    }
}
