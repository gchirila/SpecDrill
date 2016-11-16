using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SpecDrill.Infrastructure;
using SpecDrill.Infrastructure.Logging;
using SpecDrill.Infrastructure.Logging.Interfaces;

namespace SpecDrill
{
    public class RetryWaitContext
    {
        protected ILogger Log = Infrastructure.Logging.Log.Get<RetryWaitContext>();

        public int RetryCount { get; set; }
        public TimeSpan? RetryInterval { get; set; }

        private Action action = () => { return; };

        public void Until(Func<bool> waitCondition)
        {
            Stopwatch sw = new Stopwatch();

            // default retry interval is 20s
            var retryInterval = this.RetryInterval ?? TimeSpan.FromSeconds(20);
            int retryCount = this.RetryCount;
            while (retryCount >= 0)
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    Log.Error(e, $"TryingAction: retryCount={retryCount}");
                }

                retryCount--;

                sw.Start();
                while (sw.Elapsed < retryInterval)
                {
                    try
                    {
                        if (waitCondition())
                            return;
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "Wait with retry: retryCount={0}, retryInterval={1} / maxWait={2}", retryCount, this.RetryInterval ?? TimeSpan.FromSeconds(0), retryInterval);
                    }

                    Thread.Sleep(10);
                }
                sw.Reset();
            }
            sw.Stop();

            throw new TimeoutException(string.Format("Explicit Wait with Retry of (1+{0})*{1} Timed Out!", this.RetryCount, retryInterval));
        }

        public RetryWaitContext Doing(Action action)
        {
            this.action = action ?? this.action;
            return this;
        }
    }

    public class MaxWaitContext
    {
        protected static readonly ILogger Log = Infrastructure.Logging.Log.Get<MaxWaitContext>();
        public TimeSpan MaximumWait { get; set; }
        private Func<Func<bool>, bool, bool> safeWait = (waitCondition, throwException) =>
        {
            bool result = false;
            try
            {
                result = waitCondition();
            }
            catch (Exception e)
            {
                Log.Error(e, "Error on wait");
                if (throwException)
                    throw;
            }
            return result;
        };

        public void Until(Func<bool> waitCondition, bool throwException = true)
        {
            Func<bool> safeWaitCondition = () => safeWait(waitCondition, false); 
            // Note: Ignoring automation framework exceptions while waiting.
            // Always check logs on timeout to identify root cause !

            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.Elapsed < MaximumWait)
            {
                if (safeWaitCondition())
                    return;
                Thread.Sleep(33);
            }
            sw.Stop();

            if (throwException)
            {
                throw new TimeoutException(string.Format("Explicit Wait of {0} Timed Out !", this.MaximumWait));
            }
        }
    }

    public static class Wait
    {
        public static MaxWaitContext NoMoreThan(TimeSpan maximumWait)
        {
            return new MaxWaitContext { MaximumWait = maximumWait };
        }

        /// <summary>
        /// Default parameters: retryCount = 3, retryInterval = 20s
        /// </summary>
        /// <param name="retryCount"></param>
        /// <param name="retryInterval"></param>
        /// <returns></returns>
        public static RetryWaitContext WithRetry(int retryCount = 3, TimeSpan? retryInterval = null)
        {
            return new RetryWaitContext { RetryCount = retryCount, RetryInterval = retryInterval };
        }

        public static void Until(Func<bool> waitCondition)
        {
            new MaxWaitContext
            {
                MaximumWait = TimeSpan.FromMilliseconds(Globals.Configuration.MaxWait)
            }.Until(waitCondition);
        }
    }
}
