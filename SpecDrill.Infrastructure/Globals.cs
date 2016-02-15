using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecDrill.Configuration;
using SpecDrill.Infrastructure.Configuration;

namespace SpecDrill.Infrastructure
{
    public static class Globals
    {
        static Globals()
        {
            Configuration = ConfigurationManager.Settings;
        }

        public static Settings Configuration { get; set; }
    }
}
