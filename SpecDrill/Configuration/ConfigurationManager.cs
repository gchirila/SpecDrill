using System;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;

namespace SpecDrill.Configuration
{
    public class ConfigurationManager
    {
        private const string ConfigurationFileName = "specDrillConfig.json";
        protected static ILog Log = LogManager.GetLogger(typeof(ConfigurationManager));

        public static Settings Load(string jsonConfiguration = null)
        {
            if (string.IsNullOrWhiteSpace(jsonConfiguration))
            {
                Log.InfoFormat("Searcing Configuration file {0}...", ConfigurationFileName);
                var jsonConfigurationFilePath = FindConfigurationFile(AppDomain.CurrentDomain.BaseDirectory);
                
                if (string.IsNullOrWhiteSpace(jsonConfigurationFilePath))
                {
                    Log.Info("Configuration file not found.");
                    throw new FileNotFoundException("Configuration file not found");
                }

                jsonConfiguration = File.ReadAllText(jsonConfigurationFilePath);
            }
            var configuration =  JsonConvert.DeserializeObject<Settings>(jsonConfiguration);

            //var configuration = new Configuration();
            //configuration.Selenium = new SeleniumConfiguration();
            return configuration;
        }

        private static string FindConfigurationFile(string folder)
        {
            while (true)
            {
                Log.InfoFormat("Scanning {0}...", folder);

                // we need at least a valid root folder path to continue
                if (folder.Length > 2)
                {
                    var result = Directory.EnumerateFiles(folder, "*.json", SearchOption.TopDirectoryOnly).FirstOrDefault(file => file.ToLowerInvariant().EndsWith(ConfigurationFileName.ToLowerInvariant()));

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Log.InfoFormat("Found configuration file at {0}", result);
                        return result;
                    }

                    folder = GetParentFolder(folder);
                    continue;
                }
             
                return null;
            }
        }

        private static string GetParentFolder(string folder)
        {
            return folder.Remove(folder.LastIndexOf('\\'));
        }
    }
}
