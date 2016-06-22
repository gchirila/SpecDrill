using System;
using OpenQA.Selenium;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using System.Collections.Generic;

namespace SpecDrill.Adapters.WebDriver
{
    public class SeleniumElement : IElement
    {
        protected static ILogger Log = Infrastructure.Logging.Log.Get<SeleniumElement>();

        protected IBrowser browser;
        protected IElementLocator locator;
        protected IElement parent;

        public SeleniumElement(IBrowser browser, IElement parent, IElementLocator locator)
        {
            this.browser = browser;
            this.locator = locator;
            this.parent = parent;
        }


        public bool IsReadOnly
        {
            get { return this.Element.GetAttribute("readonly") != null; }
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

                return AvailabilityTest(nativeLocatedElement);
            }
        }

        private bool AvailabilityTest(IWebElement nativeLocatedElement)
        {
            Log.Info(string.Format("Starting Availability test for {0}", locator));

            var displayed = nativeLocatedElement.Displayed;
            var enabled = nativeLocatedElement.Enabled;
            var result = displayed && enabled;

            Log.Info(string.Format("Availability test result = {2} > displayed:{0}, enabled:{1}", displayed, enabled, result));

            return result;
        }
        public IBrowser Browser
        {
            get { return this.browser; }
        }

        public void Click()
        {
            
            Wait.NoMoreThan(TimeSpan.FromSeconds(30)).Until(() => this.IsAvailable);
            
            Log.Info("Clicking {0}", this.locator);
            try
            {
                this.Element.Click();
            }
            catch (StaleElementReferenceException sere)
            {
                Log.Error(sere, $"Element {this.locator} is stale!");
                throw;
            }
            catch (ElementNotVisibleException enve)
            {
                Log.Error(enve, $"Element {this.locator} is not visible!");
                throw;
            }
            catch (InvalidOperationException ioe)
            {
                Log.Error(ioe, $"Clicking Element {this.locator} caused an InvalidOperationException!");
            }
        }

        public IElement SendKeys(string keys)
        {
            this.Element.SendKeys(keys);
            return this;
        }

        public void Blur()
        {
            this.Element.SendKeys("\t");
        }

        public string Text
        {
            get { return this.Element.Text; }
        }

        public string GetAttribute(string attributeName)
        {
            try
            {
                return this.Element.GetAttribute(attributeName);
            }
            catch (StaleElementReferenceException sere)
            {
                Log.Error(sere, $"Element {this.locator} is stale!");
            }

            return null;
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

        public object NativeElement
        {
            get
            {
                List<IElement> elementContainers = new List<IElement>();

                IElement current = this.Parent;

                if (current != null)
                {
                    do
                    {
                        if (current is IControl || current is IPage)
                        {
                            elementContainers.Add(current);
                        }
                        current = current.Parent;
                    } while (current != null);
                }

                if (elementContainers.Count == 0)
                   return this.browser.FindNativeElement(this.locator) as IWebElement;

                elementContainers.Reverse();

                IWebElement currentContainer = null;

                currentContainer = elementContainers[0].NativeElement as IWebElement;
                AvailabilityTest(currentContainer);
                Log.Info($"Finding element {locator} which is nested {elementContainers.Count} level(s) deep.");
                Log.Info($"L01>{elementContainers[0].Locator}");

                if (elementContainers.Count > 1)
                    for (int i = 1; i < elementContainers.Count; i++)
                    {
                        if (currentContainer != null && AvailabilityTest(currentContainer))
                        {
                            currentContainer = currentContainer.FindElement(elementContainers[i].Locator.ToSeleniumLocator()) as IWebElement;
                            Log.Info($"L{i:00}{elementContainers[i].Locator}");
                        }
                        else
                        {
                            Log.Info($"..some error..");
                        }
                    }

                Log.Info($"LOC>{locator}");

                IWebElement nativeElement = null;
                if (currentContainer != null)
                {
                    // do not call higher level status check properties from here in order to avoid infinite recursion
                    if (AvailabilityTest(currentContainer))
                    {
                        nativeElement = currentContainer.FindElement(this.locator.ToSeleniumLocator()) as IWebElement;
                    }
                }

                return nativeElement;
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

        public IElement Parent
        {
            get
            {
                return this.parent;
            }
        }

        public IElementLocator Locator
        {
            get
            {
                return this.locator;
            }
        }
    }
}
