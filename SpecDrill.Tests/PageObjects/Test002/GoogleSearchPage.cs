using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SomeTests.PageObjects.Test002
{
    public class GoogleSearchPage : WebPage
    {
        [Find(By.CssSelector, "input#lst-ib")]
        public IElement TxtSearch { get; private set; }

        [Find(By.CssSelector, "#tsf > div.tsf-p > div.jsb > center > input[type='submit']:nth-child(1)")]
        public INavigationElement<GoogleSearchResultsPage> BtnSearch { get; private set; }
    }
}
