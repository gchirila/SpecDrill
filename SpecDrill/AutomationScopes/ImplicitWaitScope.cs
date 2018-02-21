using System;
using System.Collections.Generic;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;
using SpecDrill.SecondaryPorts.AutomationFramework;

namespace SpecDrill.AutomationScopes
{
    public sealed class ImplicitWaitScope : IDisposable
    {
        private readonly ILogger Log = Infrastructure.Logging.Log.Get<ImplicitWaitScope>();
        
        private readonly string message = null;
        private readonly IBrowserDriver browser = null;
        private readonly Stack<TimeSpan> timeoutHistory = null;
        public ImplicitWaitScope(IBrowserDriver browser, Stack<TimeSpan> timeoutHistory, TimeSpan timeout, string message = null)
        {
            this.message = message;
            this.browser = browser;
            this.timeoutHistory = timeoutHistory;
            
            lock (timeoutHistory)
            {
                timeoutHistory.Push(timeout);
                browser.ChangeBrowserDriverTimeout(timeout);
                Log.Info(string.Format("ImplicitWaitScope: Set Timeout to {0}. {1}", timeout, message ?? string.Empty));
            }
        }

        public void Dispose()
        {
            TimeSpan previousTimeout;
            lock (timeoutHistory)
            {
                previousTimeout = timeoutHistory.Pop();
                browser.ChangeBrowserDriverTimeout(previousTimeout);
            }
            
            Log.Info(string.Format("ImplicitWaitScope: Restored Timeout to {0}. {1}", previousTimeout, message ?? string.Empty));
        }

        public static ImplicitWaitScope Create(IBrowserDriver driver, Stack<TimeSpan> timeoutHistory, TimeSpan timeout, string message = null)
        {
            return new ImplicitWaitScope(driver, timeoutHistory, timeout, message);
        }
    }
}
