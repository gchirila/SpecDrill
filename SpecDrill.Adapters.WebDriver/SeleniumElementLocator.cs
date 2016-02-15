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
