using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecDrill.Infrastructure.Configuration.WebDriver.Browser.Window
{
    public class WindowConfiguration
    {
        public bool IsMaximized { get; set; }
        public int? InitialWidth { get; set; }
        public int? InitialHeight { get; set; }
    }
}
