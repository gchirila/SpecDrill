using System;
using OpenQA.Selenium;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using System.Collections.Generic;
using SpecDrill.SecondaryPorts.AutomationFramework.Model;

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
                IElement locatedElement = browser.PeekElement(this);

                var elementFound = locatedElement != null;
                if (!elementFound)
                {
                    Log.Info($"Element ({locator}) not found!");
                    return false;
                }

                var nativeLocatedElement = locatedElement.NativeElementSearchResult.NativeElement as IWebElement;

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
            Log.Info($"Starting Availability test for { $"{nativeLocatedElement.TagName}"} -> {locator}");

            var displayed = nativeLocatedElement.Displayed;
            var enabled = nativeLocatedElement.Enabled;
            var result = displayed && enabled;

            Log.Info(string.Format("Availability test result = {2} > displayed:{0}, enabled:{1}", displayed, enabled, result));

            return result;
        }
        public IBrowser Browser => this.browser;

        public void Click(bool waitForSilence = false)
        {
            if (waitForSilence) {  this.ContainingPage.WaitForSilence(); }

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

        public IElement SendKeys(string keys, bool waitForSilence = false)
        {
            if (waitForSilence) { this.ContainingPage.WaitForSilence(); }
            this.Element.SendKeys(keys);
            return this;
        }

        public void Blur(bool waitForSilence = false)
        {
            if (waitForSilence) { this.ContainingPage.WaitForSilence(); }
            this.Element.SendKeys("\t");
        }

        public string Text
        {
            get { return this.Element.Text; }
        }

        public string GetCssValue(string cssValueName)
        {
            try
            {
                return this.Element.GetCssValue(cssValueName);
            }
            catch (StaleElementReferenceException sere)
            {
                Log.Error(sere, $"Element {this.locator} is stale!");
            }

            return null;
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

        public void Hover(bool waitForSilence = false)
        {
            if (waitForSilence) { this.ContainingPage.WaitForSilence(); }
            this.browser.HoverOver(this);
        }

        public void DragAndDrop()
        {
            this.browser.DragAndDropElement(this, this);
        }

        public IElement Clear(bool waitForSilence = false)
        {
            if (waitForSilence) { this.ContainingPage.WaitForSilence(); }
            this.Element.Clear();
            return this;
        }

        public IElement SearchContainingPage(IElement element)
        {
            if (element is IPage)
                return element;

            return (element.Parent != null) ? 
                        SearchContainingPage(element.Parent) : 
                        null;
        }

        public IPage ContainingPage => SearchContainingPage(this) as IPage;

        public SearchResult NativeElementSearchResult
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
                    return this.browser.FindNativeElement(this.locator);

                elementContainers.Reverse();

                SearchResult previousContainer = null;

                previousContainer = elementContainers[0].NativeElementSearchResult;
                if (previousContainer.NativeElement == null)
                    return previousContainer;

                AvailabilityTest(previousContainer.NativeElement as IWebElement);
                Log.Info($"Finding element {locator} which is nested {elementContainers.Count} level(s) deep.");
                Log.Info($"L01>{elementContainers[0].Locator}");

                if (elementContainers.Count > 1)
                    for (int i = 1; i < elementContainers.Count; i++)
                    {
                        var containerToSearch = elementContainers[i];
                        previousContainer = SearchElementInPreviousContainer(containerToSearch, previousContainer, i);
                        if (previousContainer.NativeElement == null)
                            return previousContainer;
                    }

                Log.Info($"LOC>{locator}");

                var nativeElement = SearchElementInPreviousContainer(this, previousContainer);

                return nativeElement;
            }
        }

        private SearchResult SearchElementInPreviousContainer(IElement elementToSearch, SearchResult previousContainer, int i = -1)
        {
            var previousContainerNativeElement = previousContainer.NativeElement as IWebElement;
            
            if (previousContainer != null && AvailabilityTest(previousContainerNativeElement))
            {
                var elements = previousContainerNativeElement.FindElements(elementToSearch.Locator.ToSeleniumLocator());
                if (elementToSearch.Locator.Index > elements.Count)
                {
                    throw new Exception($"SeleniumElement.NativeElement : Not enough elements. You want element number {locator.Index} but only {elements.Count} were found.");
                }
                if (elements.Count == 0)
                {
                        return SearchResult.Create(null, 0);
                    }
                    previousContainer = SearchResult.Create(elements[(elementToSearch.Locator.Index??1) - 1], elements.Count);

                Log.Info($"L{i:00}{elementToSearch.Locator}");
            }
            else
            {
                Log.Info($"..some error.. Parent container was null...");
                // not throwing exception for now
            }

            return previousContainer;
        }

        internal IWebElement Element
        {
            get
            {
                Wait.NoMoreThan(TimeSpan.FromSeconds(10)).Until(() => this.IsAvailable);
                var nativeElement = this.NativeElementSearchResult.NativeElement as IWebElement;
                if (nativeElement == null)
                {
                    throw new Exception("Element Not Found!");
                }
                browser.ExecuteJavascript(@"arguments[0].style.border='3px solid red';", nativeElement);
                
                return nativeElement;
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

        public int Count
        {
            get
            {
                Wait.NoMoreThan(TimeSpan.FromSeconds(10)).Until(() => this.IsAvailable);
                var nativeElement = this.NativeElementSearchResult.NativeElement;
                if (nativeElement == null)
                    return 0;
                browser.ExecuteJavascript(@"arguments[0].style.border='3px solid green';", nativeElement);
                return this.NativeElementSearchResult.Count;
            }
        }
    }
}
