using System;
using OpenQA.Selenium;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using System.Collections.Generic;
using SpecDrill.SecondaryPorts.AutomationFramework.Model;
using System.Linq;
using OpenQA.Selenium.Interactions;
using SpecDrill.Adapters.WebDriver.Extensions;

namespace SpecDrill.Adapters.WebDriver
{
    internal enum ClickType
    {
        Single,
        Double
    }

    [Flags]
    public enum ElementStateFlags
    {
        None = 0,
        Displayed = 1,
        Enabled = 2
    }
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

        public bool IsAvailable => AvailabilityTest(this.ToWebElement());

        private bool AvailabilityTest(IWebElement nativeLocatedElement)
        => Test(nativeLocatedElement, "AvailabilityTest", (state) => state.HasFlag(ElementStateFlags.Displayed) && state.HasFlag(ElementStateFlags.Enabled));

        public bool IsDisplayed => Test(this.ToWebElement(), "VisibilityTest", (state) => state.HasFlag(ElementStateFlags.Displayed));
        public bool IsEnabled => Test(this.ToWebElement(), "IsEnabledTest", (state) => state.HasFlag(ElementStateFlags.Enabled));

        private Tuple<ElementStateFlags?, Exception> InternalElementState
        {
            // (null, exception) -> inconclusive - not yet present
            // (ESF.None, exception) -> conclusive - present but invalid object type ???
            // (ESF.None, null) -> Item statie is according to ESF flags : is not shown and not enabled
            // (ESF.*, null) -> Item state is according to ESF flags
            get
            {
                Exception exception = null;
                SearchResult searchResult = null;
                try { searchResult = browser.PeekElement(this); }
                catch (NotFoundException nfe)
                {
                    exception = nfe;
                    Log.Error(exception, "SpecDrill: Availability Test");
                    return Tuple.Create((ElementStateFlags?)null, exception);
                }

                if (!searchResult.HasResult)
                {
                    var info = $"Element ({locator}) not found!";
                    Log.Info(info);
                    exception = new NotFoundException(info);
                    return Tuple.Create((ElementStateFlags?)null, exception);
                }

                var locatedElement = searchResult.NativeElement as IWebElement;
                if (locatedElement == null)
                {
                    var info = $"Element ({ searchResult.NativeElement?.GetType().ToString() ?? "(null)" }) is not an IWebElement!";
                    Log.Info(info);
                    return Tuple.Create((ElementStateFlags?)ElementStateFlags.None, new Exception(info, exception));
                }

                return InternalStateTest(locatedElement);
            }
        }

        private bool Test(IWebElement nativeLocatedElement, string testName, Func<ElementStateFlags, bool> test)
        {
            var result = InternalStateTest(nativeLocatedElement);

            if (result.Item2 != null)
            {
                Log.Info(string.Format($"{testName} test result: false ; Reason {(result.Item2?.ToString() ?? "(null)")}"));
                return false;
            }

            var testResult = result.Item1.HasValue && test(result.Item1.Value);

            if (result.Item1.HasValue && !testResult)
            {
                var state = result.Item1.Value;
                Log.Info(string.Format($"{testName} result: false > displayed:{state.HasFlag(ElementStateFlags.Displayed)}, enabled:{state.HasFlag(ElementStateFlags.Enabled)}"));
            }

            return testResult;
        }

        private Tuple<ElementStateFlags?, Exception> InternalStateTest(IWebElement nativeLocatedElement)
        {
            ElementStateFlags state = ElementStateFlags.None;
            Exception exception = null;
            try
            {
                Log.Info($"Testing State for { $"{nativeLocatedElement.TagName}"} -> {locator}");
                if (nativeLocatedElement.Displayed) state |= ElementStateFlags.Displayed;
                if (nativeLocatedElement.Enabled) state |= ElementStateFlags.Enabled;

                return Tuple.Create((ElementStateFlags?)state, exception);

            }
            catch (StaleElementReferenceException sere)
            {
                exception = sere;
                Log.Error(exception, "SpecDrill: State Test");
            }
            catch (NotFoundException nfe)
            {
                exception = nfe;
                Log.Error(exception, "SpecDrill: State Test");
            }
            catch (Exception e)
            {
                exception = e;
                Log.Error(exception, "SpecDrill: State Test");
            }

            return Tuple.Create((ElementStateFlags?)state, exception);
        }

        public IBrowser Browser => this.browser;

        private void Click(ClickType clickType, bool waitForSilence = false)
        {
            if (waitForSilence) { this.ContainingPage.WaitForSilence(); }

            Log.Info("Clicking {0}", this.locator);
            try
            {
                if (clickType == ClickType.Single)
                {
                    this.Element.Click();
                }
                else
                {
                    this.browser.DoubleClick(this);
                }
            }
            catch (StaleElementReferenceException sere)
            {
                Log.Error(sere, $"Click: Element {this.locator} is stale!");
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

        public void DoubleClick(bool waitForSilence = false) => this.Click(ClickType.Double, waitForSilence);

        public void Click(bool waitForSilence = false) => this.Click(ClickType.Single, waitForSilence);

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
                Log.Error(sere, $"GetCssValue: Element {this.locator} is stale!");
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
                Log.Error(sere, $"GetAttribute: Element {this.locator} is stale!");
            }
            catch (Exception e)
            {
                string z = e.Message;
            }

            return null;
        }

        public void Hover(bool waitForSilence = false)
        {
            if (waitForSilence) { this.ContainingPage.WaitForSilence(); }
            this.browser.Hover(this);
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
                List<IElement> elementContainers = DiscoverElementContainers();

                if (elementContainers.Count == 0)
                    return this.browser.FindNativeElement(this.Locator);

                elementContainers.Reverse();

                SearchResult previousContainer = this.browser.FindNativeElement(elementContainers.First().Locator);

                if (!previousContainer.HasResult)
                    return SearchResult.Empty;

                bool isParentAvailable = AvailabilityTest(previousContainer.NativeElement as IWebElement);

                Log.Info($"Finding element {locator} which is nested {elementContainers.Count} level(s) deep. Its parent is{(isParentAvailable ? string.Empty : " not")} available.");
                Log.Info($"L01>{elementContainers.First().Locator}");

                if (elementContainers.Count > 1)
                {
                    for (int i = 1; i < elementContainers.Count; i++)
                    {
                        var containerToSearch = elementContainers[i];
                        previousContainer = SearchElementInPreviousContainer(containerToSearch, previousContainer, i);

                        if (!previousContainer.HasResult)
                            return SearchResult.Empty;
                    }
                }

                Log.Info($"LOC>{locator}");

                return SearchElementInPreviousContainer(
                    elementToSearch: this,
                    previousContainer: previousContainer);
            }
        }

        private List<IElement> DiscoverElementContainers()
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

            return elementContainers;
        }

        private SearchResult SearchElementInPreviousContainer(IElement elementToSearch, SearchResult previousContainer, int i = -1)
        {
            if (previousContainer == null || !previousContainer.HasResult)
                return SearchResult.Empty;

            var previousContainerNativeElement = previousContainer.NativeElement as IWebElement;

            if (AvailabilityTest(previousContainerNativeElement))
            {
                try
                {
                    var elements = previousContainerNativeElement.FindElements(elementToSearch.Locator.ToSeleniumLocator());
                    if ((elementToSearch.Locator.Index ?? 0) > elements.Count)
                    {
                        throw new Exception($"SpecDrill: SeleniumElement.NativeElement : Not enough elements. You want element number {locator.Index} but only {elements.Count} were found.");
                    }
                    if (elements.Count == 0)
                    {
                        return SearchResult.Empty;
                    }
                    previousContainer = SearchResult.Create(elements[(elementToSearch.Locator.Index ?? 1) - 1], elements.Count);
                }
                catch (StaleElementReferenceException sere)
                {
                    Log.Error(sere, $"L{i:00}{elementToSearch.Locator} - Is Stale !");
                    return SearchResult.Empty;
                }
                Log.Info($"L{i:00}{elementToSearch.Locator}");
            }
            else
            {
                Log.Info($"..some error.. Parent container was null...");
                // not throwing exception for now
            }

            return previousContainer;
        }

        public void DragAndDropTo(IElement target)
        {
            this.browser.DragAndDrop(this, target);
        }

        public void DragAndDropAt(int offsetX, int offsetY)
        {
            this.browser.DragAndDrop(this, offsetX, offsetY);
        }

        internal IWebElement Element
        {
            get
            {
                Wait.Until(() => this.IsAvailable);
                var nativeElement = this.NativeElementSearchResult.NativeElement as IWebElement;
                if (nativeElement == null)
                {
                    throw new Exception("SpecDrill: Element Not Found!");
                }

                browser.ExecuteJavascript(@"arguments[0].style.outline='1px solid red';", nativeElement);

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
                browser.ExecuteJavascript(@"arguments[0].style.outline='1px solid green';", nativeElement);
                return this.NativeElementSearchResult.Count;
            }
        }
    }
}
