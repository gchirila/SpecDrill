using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using SpecDrill.AutomationScopes;

namespace SpecDrill
{
    public class WebPage
    {
        protected ILog Log = log4net.LogManager.GetLogger(typeof (WebPage));

        public WebPage(Browser browser, string title)
        {
            this.Title = title;
            this.Browser = browser;
        }

        public string Title { get; private set; }
        protected Browser Browser { get; set; }

        public bool LoadCompleted
        {
            get
            {
                string retrievedTitle = null;
                try
                {
                    retrievedTitle = Browser.PageTitle;
                }
                catch (Exception e)
                {
                    Log.Error("Cannot read page Title!", e);
                }

                var isLoaded = retrievedTitle != null &&
                               Regex.IsMatch(retrievedTitle, this.Title);

                Log.InfoFormat("LoadCompleted = {0}, retrievedTitle = {1}, patternToMatch = {2}", isLoaded, retrievedTitle ?? "(null)",
                    this.Title ?? "(null)");

                return isLoaded;
            }
        }

        public void Load()
        {
           
        }
    }
}
