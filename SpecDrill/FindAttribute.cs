using SpecDrill.SecondaryPorts.AutomationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class FindAttribute : Attribute
    {
        public By SelectorType { get; }
        public string SelectorValue { get; }
        public bool Nested { get; set; } = true;

        public FindAttribute(By selectorType, string selectorValue)
        {
            this.SelectorType = selectorType;
            this.SelectorValue = selectorValue;
        }
    }
}
