using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using SpecDrill.Configuration;
using SpecDrill.Enums;

namespace SpecDrill
{
    public class Browser
    {
        private ILog Log = log4net.LogManager.GetLogger(typeof (Browser)); 

        protected Settings Configuration;
        protected Browser(Settings configuration)
        {
            this.Configuration = configuration;
        }

        public virtual void Initialize()
        {
        }

        public object Open<T>()
            where T: WebPage
        {
            var homePage = Configuration.Homepages.FirstOrDefault(homepage => homepage.PageObjectType == typeof (T).Name);
            if (homePage != null)
            {
                this.PerformAction(typeof(T), () => this.GoToUrl(homePage.Url));
                return Activator.CreateInstance<T>();
            }

            throw new Exception(string.Format("Page ({0}) cannot be found in Homepages section of settings file.", typeof(T).Name));
        }

        protected virtual void GoToUrl(string url)
        {
        }

        public static string PageTitle { get; set; }

        private readonly Dictionary<Type, Action> pageObjectTriggerActions = new Dictionary<Type, Action>(); 
        
        internal void RepeatAction(Type targetPageObjectType)
        {
            if (pageObjectTriggerActions.ContainsKey(targetPageObjectType))
            {
                pageObjectTriggerActions[targetPageObjectType]();
                Log.InfoFormat("Repeated Action For Targeting {0} PageObject", targetPageObjectType);
            }
            else
            {
                Log.InfoFormat("Cannot Repeat Action. No Action was performed For Targeting {0} PageObject", targetPageObjectType);   
            }
        }

        internal void PerformAction(Type targetPageObjectType, Action trigger)
        {
            pageObjectTriggerActions.Add(targetPageObjectType, trigger);
            pageObjectTriggerActions[targetPageObjectType]();
            Log.InfoFormat("Performing Action For Targeting {0} PageObject", targetPageObjectType);
        }
    }
}
