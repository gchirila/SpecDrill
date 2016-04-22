using SpecDrill.Adapters.WebDriver;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SpecDrill
{
    public class ElementLocator
    {
        public static IElementLocator Create(By locatorKind, string locatorValue)
        {
            return new SeleniumElementLocator(locatorKind, locatorValue);
        }
    }
}
