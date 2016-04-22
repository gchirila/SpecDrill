using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Adapters.WebDriver
{
    public class SeleniumElementLocator : IElementLocator
    {
        private readonly By locatorType;
        private readonly string locatorValue;
        
        public SeleniumElementLocator(By locatorKind, string locatorValue)
        {
            this.locatorType = locatorKind;
            this.locatorValue = locatorValue;
        }

        public override string ToString()
        {
            return string.Format("By: {0} -> `{1}`", locatorType, locatorValue);
        }

        /// <summary>
        /// Creates new Locator by Appending index information to current Locator
        /// </summary>
        /// <param name="index"> index is one based! </param>
        /// <returns></returns>
        public IElementLocator WithIndex(int index)
        {
            if (index < 1)
                throw new ArgumentException("Locator Index is 1-based");

            switch (this.locatorType)
            {
                case By.CssSelector:
                    return new SeleniumElementLocator(this.LocatorType, $"{this.locatorValue}:nth-of-type({index})");
                case By.XPath:
                    return new SeleniumElementLocator(this.LocatorType, $"{this.locatorValue}[{index}]");
                default:
                    throw new Exception("Invalid Locator Type. You can index only CSS or XPath selectors!");
            }
        }

        public By LocatorType
        {
            get { return locatorType; }
        }

        public string LocatorValue
        {
            get { return locatorValue; }
        }
    }
}
