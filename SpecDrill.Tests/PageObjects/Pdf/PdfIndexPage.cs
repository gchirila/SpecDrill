﻿using SpecDrill;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SomeTests.PageObjects.Pdf
{
    public class PdfIndexPage : WebPage
    {
        [Find(By.LinkText, "View Pdf")]
        public IWindowElement<MyPdfPage> LnkViewPdf;
    }
}
