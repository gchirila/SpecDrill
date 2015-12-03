using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecDrill;

namespace SomeTests.PageObjects.Test000
{
    public class Test000Page : WebPage
    {
        public Test000Page(Browser browser)
            : base(browser, "Virtual Store - Login")
        {
        }
    }
}
