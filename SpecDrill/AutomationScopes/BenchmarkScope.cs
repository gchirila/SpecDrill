using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SpecDrill.AutomationScopes
{
    public class BenchmarkScope : IDisposable
    {
         protected readonly ILog Log = LogManager.GetLogger(typeof(BenchmarkScope));

        private readonly Stopwatch stopwatch;
        private readonly string description;

        public BenchmarkScope(string description)
        {
            this.description = description;
            stopwatch = new Stopwatch();

            Log.Info(string.Format("Starting Stopwatch for {0}", description));

            stopwatch.Start();
        }

        public TimeSpan Elapsed {
            get { return stopwatch.Elapsed; }
        }

        public void Dispose()
        {
            stopwatch.Stop();
            Log.Info(string.Format("Stopped Stopwatch for {0}. Elapsed = {1}", description, stopwatch.Elapsed));
        }
    }
}
