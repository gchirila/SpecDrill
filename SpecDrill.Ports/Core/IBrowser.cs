using SpecDrill.SecondaryPorts.AutomationFramework.Model;
using System;
using System.Collections.Generic;

namespace SpecDrill.SecondaryPorts.AutomationFramework.Core
{
    public interface IBrowser
    {
        T Open<T>()
            where T: IPage;

        T CreatePage<T>()
            where T : IPage;

        void GoToUrl(string url);

        string PageTitle { get; }

        /// <summary>
        /// returns an IDisposable that changes browser driver's timeout and restores it to previous value at end of using scope/when disposed
        /// </summary>
        /// <param name="implicitTimeout"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        IDisposable ImplicitTimeout(TimeSpan implicitTimeout, string message = null);

        /// <summary>
        /// Returns instance of element if present or null if not available.
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        IElement PeekElement(IElement locator);

        void Exit();

        IElement FindElement(IElementLocator locator);

        IList<IElement> FindElements(IElementLocator locator);

        SearchResult FindNativeElement(IElementLocator locator);

        object ExecuteJavascript(string script, params object[] arguments);

        void HoverOver(IElement element);

        void DragAndDropElement(IElement startFromElement, IElement stopToElement);

        void MaximizePage();

        void RefreshPage();
        
    }
}