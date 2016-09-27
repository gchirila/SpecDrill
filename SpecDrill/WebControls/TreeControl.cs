//using SpecDrill.SecondaryPorts.AutomationFramework;
//using System;
//using System.Collections.Generic;
//using SpecDrill.SecondaryPorts.AutomationFramework.Core;
//using System.Collections;
//using System.Text.RegularExpressions;

//namespace SpecDrill.WebControls
//{
//    public class TreeElement<TRoot, TNode, TLeaf> : WebControl, IReadOnlyList<T>
//        where TRoot : WebControl, IElement
//        where TNode : WebControl, IElement
//        where TLeaf : WebControl, IElement
//    {
//        protected IElementLocator locator;
//        protected IBrowser browser;
//        protected IElement parent;

//        public TreeElement(IBrowser browser, IElement parent, IElementLocator rootLocator) : base(browser, parent, locator)
//        {
//            this.browser = browser;
//            this.parent = parent;
//            this.locator = locator;

//            if (locator.LocatorType != By.XPath && locator.LocatorType != By.CssSelector)
//                throw new ArgumentException("Only Css or XPath locators are accepted!");
//        }

//        public int Count { get { return this.browser.FindElements(this.locator)?.Count ?? 0; } }

//        public bool IsReadOnly => true;

//        public void Add(T item) { throw new NotImplementedException(); }

//        public void Clear() { throw new NotImplementedException(); }

//        // TODO: Implement
//        public bool Contains(T item) { throw new NotImplementedException(); }

//        public void CopyTo(T[] array, int arrayIndex) { throw new NotImplementedException(); }

//        public IEnumerator<T> GetEnumerator()
//        {
//            //for (int i = 0; i < this.Count; i++)
//            //{
//            //    var currentElement = this[i];
//            //    yield return currentElement;
//            //}
//            return this.GetEnumerator();
//        }

//        public int IndexOf(T item)
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(int index, T item)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Remove(T item)
//        {
//            throw new NotImplementedException();
//        }

//        public void RemoveAt(int index)
//        {
//            throw new NotImplementedException();
//        }
//        public T GetElementByText(string regex)
//        {
//            for (int i = 1; i <= this.Count; i++)
//            {
//                var element = this[i];

//                if (Regex.IsMatch(element.Text, regex))
//                {
//                    return element;
//                }
//            }
//            throw new Exception($"No element matching '{regex}' was found!");
//        }

//        public U GetChildNodeByText<U>(T node, IElementLocator childrenLocator, string regex)
//            where U : WebControl, IElement
//        {
//            var children = new ListElement<U>(this.browser, node, childrenLocator);
//            return children.GetElementByText(regex);
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            for (int i = 0; i < this.Count; i++)
//            {
//                var currentElement = this[i];
//                yield return currentElement;
//            }
//        }
//    }
//}
