using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SomeTests.PageObjects.Test001
{
    public class Test001CalculatorPage : WebPage
    {
        public IElement TxtOperand1 { get; private set; }
        public IElement TxtOperand2 { get; private set; }

        public IElement BtnAdd { get; private set; }

        public IElement TxtResult { get; private set; }

        public Test001CalculatorPage()
            : base("Calculator")
        {
            this.TxtOperand1 = WebElement.Create(this, ElementLocator.Create(By.Id, "operand1"));
            this.TxtOperand2 = WebElement.Create(this, ElementLocator.Create(By.Id, "operand2"));
            this.BtnAdd = WebElement.Create(this, ElementLocator.Create(By.Id, "add"));
            this.TxtResult = WebElement.CreateSelect(this, ElementLocator.Create(By.Id, "result"));
        }
    }
}
