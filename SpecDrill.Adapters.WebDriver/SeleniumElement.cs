using System;
using OpenQA.Selenium;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill.Adapters.WebDriver
{
    public class SeleniumElement : IElement
    {
        protected static ILogger Log = Infrastructure.Logging.Log.Get<SeleniumElement>();

        protected IBrowser browser;
        protected IElementLocator locator;

        public SeleniumElement(IBrowser browser, IElement parent, IElementLocator locator)
        {
            this.browser = browser;
            this.locator = locator;
        }

        
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAvailable
        {
            get
            {
                IElement locatedElement = browser.PeekElement(this.locator);
                
                var elementFound = locatedElement != null;
                if (!elementFound)
                {
                    Log.Info(string.Format("Element ({0}) not found!", locator));
                    return false;
                }

                var nativeLocatedElement = locatedElement.NativeElement as IWebElement;

                if (nativeLocatedElement == null)
                {
                    Log.Info(string.Format("Element ({0}) is not an IWebElement!"));
                    return false;
                }

                Log.Info(string.Format("Starting Availability test for {0}", locator));

                var displayed = nativeLocatedElement.Displayed;
                var enabled = nativeLocatedElement.Enabled;
                var result = displayed && enabled;

                Log.Info(string.Format("Availability test result = {2} > displayed:{0}, enabled:{1}", displayed, enabled, result));
                
                return result;
            }
        }

        public IBrowser Browser
        {
            get { return this.browser; }
        }

        public void Click()
        {
            Wait.NoMoreThan(TimeSpan.FromSeconds(30)).Until(() => this.IsAvailable);

            Log.Info("Clicking {0}", this.locator);
            this.Element.Click();
        }

        public void SendKeys(string keys)
        {
            this.Element.SendKeys(keys);
        }

        public IElement FindSubElement(IElementLocator locator)
        {
            throw new NotImplementedException();
        }

        public IElement Blur()
        {
            this.Element.SendKeys("\t");
            return this;
        }

        public string Text
        {
            get { return this.Element.Text; }
        }

        public string GetAttribute(string attributeName)
        {
            return this.Element.GetAttribute(attributeName);
        }

        public void Hover()
        {
            this.browser.HoverOver(this);
        }

        public IElement Clear()
        {
            this.Element.Clear();
            return this;
        }

        private IWebElement nativeElement = null; 
        public object NativeElement
        {
            get
            {
                // do not call higher level status check properties from here in order to avoid infinite recursion
                if (this.nativeElement == null)
                {
                    this.nativeElement = this.browser.FindNativeElement(this.locator) as IWebElement;
                }

                return this.nativeElement;
            }
        }

        internal IWebElement Element
        {
            get
            {
                Wait.NoMoreThan(TimeSpan.FromSeconds(10)).Until(() => this.IsAvailable);
                browser.ExecuteJavascript(@"arguments[0].style.border='3px solid red';", this.NativeElement);
                return this.NativeElement as IWebElement;
            }
        }

    }
}
