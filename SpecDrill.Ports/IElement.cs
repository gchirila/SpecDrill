using SpecDrill.SecondaryPorts.AutomationFramework.Core;

namespace SpecDrill.SecondaryPorts.AutomationFramework
{
    public interface IElement
    {
        /// <summary>
        /// Native Element
        /// </summary>
        object NativeElement { get; }

        /// <summary>
        /// Checks if the element is in a read-only mode (read-only or disabled)
        /// </summary>
        bool IsReadOnly { get; }

        /// <summary>
        /// Checks if the element is drawn on screen and ready for interaction (shown and enabled)
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Underlying Browser object responsible with browser interaction
        /// </summary>
        IBrowser Browser { get; }

        void Click();

        /// <summary>
        /// Text to send into textbox
        /// </summary>
        /// <param name="keys"></param>
        void SendKeys(string keys);

        /// <summary>
        /// find subelement
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        IElement FindSubElement(IElementLocator locator);

        /// <summary>
        /// lose focus
        /// </summary>
        /// <returns></returns>
        IElement Blur();

        string Text { get; }

        string GetAttribute(string attributeName);

        void Hover();
    }
}