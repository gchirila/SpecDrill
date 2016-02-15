using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SpecDrill.AutomationScopes;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill
{
    public class WebPage : IPage
    {
        protected ILogger Log = Infrastructure.Logging.Log.Get<WebPage>();

        public WebPage(Browser browser, string title)
        {
            this.Title = title;
            this.Browser = browser;
            rootElement = WebElement.Create(browser, null, Locator.Create(By.TagName, "html"));
        }

        public string Title { get; private set; }
        public IBrowser Browser { get; set; }

        public bool IsLoadCompleted
        {
            get
            {
                object result = 
                this.Browser.ExecuteJavascript(@"
                    if (document.readyState !== 'complete') {
                        return false;
                    }
                    if ((!document.jQuery) || (document.jQuery.active || (document.jQuery.ajax && document.jQuery.ajax.active))) {
                        return false;
                    } 
				    if (document.angular) {
                        if (!window.specDrill) {
                            window.specDrill = { silence : false };
                        }
                        var injector = window.angular.element('body').injector();
                        var $rootScope = injector.get('$rootScope');
                        var $http = injector.get('$http');
                        var $timeout = injector.get('$timeout');
                         
                        if ($rootScope.$$phase === '$apply' || $rootScope.$$phase === '$digest' || $http.pendingRequests.length != 0) {
                            window.specDrill.silence = false;
                            return false;
                        }

                        if (!window.specDrill.silence) {
                            $timeout(function () { window.specDrill.silence = true; }, 0);
                            return false;
                        }
                    }
                    return true;
                ");
                string retrievedTitle = null;
                try
                {
                    retrievedTitle = Browser.PageTitle;
                }
                catch (Exception e)
                {
                    Log.Error("Cannot read page Title!", e);
                }

                var isLoaded = retrievedTitle != null &&
                               Regex.IsMatch(retrievedTitle, this.Title);

                Log.Info("LoadCompleted = {0}, retrievedTitle = {1}, patternToMatch = {2}", isLoaded, retrievedTitle ?? "(null)",
                    this.Title ?? "(null)");

                return isLoaded;
            }
        }

        private readonly IElement rootElement = null;
        public IElement Element
        {
            get { return rootElement; }
        }

        public object NativeElement
        {
            get { return rootElement.NativeElement; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAvailable
        {
            get { return this.rootElement.IsAvailable; }
        }

        public void Click()
        {
            rootElement.Click();
        }

        public void SendKeys(string keys)
        {
            throw new InvalidOperationException();
        }

        public IElement FindSubElement(IElementLocator locator)
        {
            return this.Browser.FindElement(locator);
        }

        public IElement Blur()
        {
           throw new InvalidOperationException();
        }

        public virtual bool IsPageLoaded
        {
            get { return this.IsLoadCompleted; }
        }
        // try and see if virtual IsPageLoaded can be used to sum up all kinds of wait (static, jQuery, Angular1, Angular2, etc)
        // goal is to have an immediately returning test so we can wait on it
        // currently there is no IsPageLoaded method on IPage so we can use in lambda


        public string Text
        {
            get { return this.rootElement.Text; }
        }

        public string GetAttribute(string attributeName)
        {
            return this.rootElement.GetAttribute(attributeName);
        }

        public void Hover()
        {
            this.rootElement.Hover();
        }

        public IElement Clear()
        {
            this.Element.SendKeys(OpenQA.Selenium.Keys.Control + "A");
            this.Element.SendKeys(OpenQA.Selenium.Keys.Delete);
            return this;
        }
    }
}
