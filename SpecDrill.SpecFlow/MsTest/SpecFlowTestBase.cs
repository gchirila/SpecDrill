using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecDrill.SpecFlow.MsTest
{
    public class SpecFlowTestBase : SpecDrill.MsTest.TestBase
    {
        [BeforeScenario]
        public void ScenarioSetUp()
        {
            base._TestSetUp();
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            base._TestTearDown();
        }
    }
}
