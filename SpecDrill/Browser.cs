using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using SpecDrill.Adapters.WebDriver;
using SpecDrill.Adapters.WebDriver.ElementLocatorExtensions;
using SpecDrill.AutomationScopes;
using SpecDrill.Configuration;
using SpecDrill.Infrastructure;
using SpecDrill.Infrastructure.Enums;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using SpecDrill.SecondaryPorts.AutomationFramework.Model;
using System.IO;

namespace SpecDrill
{
    public class Browser : IBrowser
    {
        private static IBrowser browserInstance = null;

        private readonly Settings configuration;

        private ILogger Log = Infrastructure.Logging.Log.Get<Browser>();

        private readonly IBrowserDriver browserDriver;

        private static readonly Stack<TimeSpan> timeoutHistory = new Stack<TimeSpan>();

        public Browser(Settings configuration)
        {
            this.configuration = configuration;

            var driverFactory = new SeleniumBrowserFactory(configuration);

            var browserName = configuration.WebDriver.BrowserDriver.ToEnum<BrowserNames>();

            browserDriver = driverFactory.Create(browserName);

            var cfgMaxWait = TimeSpan.FromMilliseconds(configuration.MaxWait == 0 ? 60000 : configuration.MaxWait);

            // set initial browser driver timeout to configuration or 1 minute if not defined
            lock (timeoutHistory)
            {
                timeoutHistory.Push(cfgMaxWait);
                browserDriver.ChangeBrowserDriverTimeout(cfgMaxWait);
            }

            browserInstance = this;
        }

        public static IBrowser Instance => browserInstance;

        public T Open<T>()
            where T : IPage
        {
            var homePage = configuration.Homepages.FirstOrDefault(homepage => homepage.PageObjectType == typeof(T).Name);
            if (homePage != null)
            {

                Action navigateToUrl = homePage.IsFileSystemPath ?
                    (Action)(() =>
                    this.GoToUrl(
                        string.Format("file:///{0}{1}",
                            Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).Replace('\\', '/'),
                            homePage.Url)))
                    : () => this.GoToUrl(homePage.Url);

                navigateToUrl();

                var targetPage = this.CreatePage<T>();

                Wait.WithRetry().Doing(navigateToUrl).Until(() => targetPage.IsLoaded);
                targetPage.WaitForSilence();
                return targetPage;
            }

            throw new Exception($"SpecDrill: Page ({typeof(T).Name}) cannot be found in Homepages section of settings file.");
        }

        public T CreatePage<T>()
            where T : IPage
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public void GoToUrl(string url)
        {
            browserDriver.GoToUrl(url);
        }

        public string PageTitle
        {
            get { return browserDriver.Title; }
        }

        public bool IsAlertPresent => this.browserDriver.Alert != null;

        public IBrowserAlert Alert
        {
            get
            {
                var alert = this.browserDriver.Alert;
                if (alert == null)
                    throw new Exception("SpecDrill: No alert present!");
                return alert;
            }
        }

        public IDisposable ImplicitTimeout(TimeSpan timeout, string message = null)
        {
            return new ImplicitWaitScope(browserDriver, timeoutHistory, timeout, message);
        }

        //public IElement PeekElement(IElementLocator locator)
        //{
        //    using (ImplicitTimeout(TimeSpan.FromSeconds(1)))
        //    {
        //        var webElement = WebElement.Create(this, null, locator);
        //        var nativeElement = webElement.NativeElement;
        //        return nativeElement == null ? null : webElement;
        //    }
        //}

        public SearchResult PeekElement(IElement element)
        {
            var webElement = WebElement.Create(element.Parent, element.Locator);
            return webElement.NativeElementSearchResult;
        }

        public void Exit()
        {
            browserDriver.Exit();
        }

        //public IElement FindElement(IElementLocator locator)
        //{
        //    return WebElement.Create(null, locator);
        //}

        //public IList<IElement> FindElements(IElementLocator locator)
        //{
        //    var elements = this.browserDriver.FindElements(locator);

        //    var elementCount = elements?.Count ?? 0;

        //    var result = new List<IElement>();
        //    if (elementCount > 0)
        //    {
        //        for (int i=0; i<elements.Count; i++)
        //        {
        //            result.Add(WebElement.Create(null, locator));
        //        }
        //    }

        //    return result;
        //}

        public SearchResult FindNativeElement(IElementLocator locator)
        {
            var elements = browserDriver.FindElements(locator);
            int index = 0;
            int count = 1;

            if (locator.Index.HasValue)
            {
                if (locator.Index > elements.Count)
                {
                    throw new IndexOutOfRangeException($"SpecDrill: Browser.FindNativeElement : Not enough elements. You want element number {locator.Index} but only {elements.Count} were found.");
                }
                index = locator.Index.Value;
                count = elements.Count;
            }

            //if (elements.Count == 0)
            //{
            //    throw new IndexOutOfRangeException($"SpecDrill: No elements found.");
            //}

            return SearchResult.Create(elements.Count > 0 ? elements[index] : null, elements.Count);
        }

        public object ExecuteJavascript(string js, params object[] arguments)
        {
            return browserDriver.ExecuteJavaScript(js, arguments);
        }

        public void Hover(IElement element)
        {
            browserDriver.MoveToElement(element);
        }

        public void Click(IElement element)
        {
            browserDriver.Click(element);
        }
        public void DragAndDropElement(IElement startFromElement, IElement stopToElement)
        {
            browserDriver.DragAndDropElement(startFromElement, stopToElement);
        }

        public void RefreshPage()
        {
            browserDriver.RefreshPage();
        }

        public void MaximizePage()
        {
            browserDriver.MaximizePage();
        }

        public void SwitchToDocument()
        {
            browserDriver.SwitchToDocument();
        }
         
        void IBrowser.SwitchToFrame<T>(IFrameElement<T> seleniumFrameElement)
        {
            browserDriver.SwitchToFrame(seleniumFrameElement);
        }
    }
}
