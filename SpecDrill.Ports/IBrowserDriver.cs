using System.Collections.ObjectModel;

namespace SpecDrill.SecondaryPorts.AutomationFramework
{
    public interface IBrowserDriver
    {
        /// <summary>
        /// Navigates to specified Url
        /// </summary>
        /// <param name="url"></param>
        void GoToUrl(string url);
        
        /// <summary>
        /// Closes Browser Window
        /// </summary>
        void Exit();

        /// <summary>
        /// Current Page's Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Changes underlying framework's implicit wait timeout
        /// </summary>
        /// <param name="timeout"></param>
        void ChangeBrowserDriverTimeout(System.TimeSpan timeout);

        /// <summary>
        /// Finds elements matching provided locator
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        ReadOnlyCollection<object> FindElements(IElementLocator locator);

        /// <summary>
        /// returns native element. Cannot return IElement since we need an IBrowser instance for creation.
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        //object FindElement(IElementLocator locator);

        object ExecuteJavaScript(string js, params object[] elements);

        void MoveToElement(IElement locator);

        void DragAndDropElement(IElement startFromElement, IElement stopToElement);

        void RefreshPage();

        void MaximizePage();

        void Click(IElement element);

        IBrowserAlert Alert { get; }

        bool IsAlertPresent { get; }
    }
}
