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
        public IElement TxtSearch { get; private set; }

        public INavigationElement<GoogleSearchResultsPage> BtnSearch { get; private set; }

        public IElement TxtResult { get; private set; }
        public GoogleSearchPage(string title) : base(title)
        {
            InitFields();
        }
        public GoogleSearchPage()
            : base("")
        {
            InitFields();
        }

        private void InitFields()
        {
            this.TxtSearch = WebElement.Create(this, ElementLocator.Create(By.CssSelector, "input#lst-ib"));
            this.BtnSearch = WebElement.CreateNavigation<GoogleSearchResultsPage>(this, ElementLocator.Create(By.CssSelector, "button.lsb>span.sbico"));
        }
    }
}
