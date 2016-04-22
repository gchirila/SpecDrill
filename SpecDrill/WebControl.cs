using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using SpecDrill.SecondaryPorts.AutomationFramework.Core;
using System.Collections;

namespace SpecDrill
{
    public class WebControl : ElementBase, IControl
    {
        public WebControl(IBrowser browser, IElement parent, IElementLocator locator) : base(browser, parent, locator)
        {
        }

        public bool IsLoaded
        {
            get
            {
                return this.rootElement.IsAvailable;
            }
        }
    }
     
    public class ListElement<T> : IReadOnlyList<T>
        where T : WebControl, IElement
    {
        protected IElementLocator locator;
        protected IBrowser browser;
        protected IElement parent;
        protected IList<IElement> elements = new List<IElement>();

        public ListElement(IBrowser browser, IElement parent, IElementLocator locator)
        {
            this.browser = browser;
            this.parent = parent;
            this.locator = locator;

            if (locator.LocatorType != By.XPath && locator.LocatorType != By.CssSelector)
                throw new ArgumentException("Only Css or XPath locators are accepted!");
        }

        public void Refresh()
        {
            this.elements = new List<IElement>();
        }

        public T this[int index]
        {
            get
            {
                if ((this.elements?.Count ?? 0) == 0)
                {
                    this.elements = this.browser.FindElements(this.locator) ?? new List<IElement>();
                }
                return this.elements[index] as T;
            }
        }

        public int Count { get { return this.browser.FindElements(this.locator)?.Count ?? 0; } }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        private string BuildXPathForElementAt(int index)
        {
            if (index < 1)
                throw new IndexOutOfRangeException("XPath index is always > 0!");

            return $"{this.locator.LocatorValue}[{index}]";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
