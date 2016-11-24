using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace $rootnamespace$.PageObjects
{
    public class GoogleSearchPage : WebPage
    {
        [Find(By.CssSelector, "input#lst-ib")]
        public IElement TxtSearch { get; private set; }

        [Find(By.CssSelector, "button>span.sbico")]
        public INavigationElement<GoogleSearchResultsPage> BtnSearch { get; private set; }
    }
}
