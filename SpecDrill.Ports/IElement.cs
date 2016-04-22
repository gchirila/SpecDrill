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
        /// Sends text to input
        /// </summary>
        /// <param name="keys">Text to send into textbox</param>

        IElement SendKeys(string keys);

        /// <summary>
        /// Lose element focus
        /// </summary>
        /// <returns></returns>
        void Blur();

        /// <summary>
        /// Clears input
        /// </summary>
        /// <returns></returns>
        IElement Clear();

        string Text { get; }

        /// <summary>
        /// Gets html element attribute value
        /// </summary>
        /// <param name="attributeName">Element atribute's name</param>
        /// <returns>attribute value, or null if attribute not present</returns>
        string GetAttribute(string attributeName);

        void Hover();

        IElement Parent { get; }

        IElementLocator Locator { get; }
    }
}