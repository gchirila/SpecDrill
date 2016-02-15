using System;
using System.IO;
using System.Linq;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using SpecDrill.Configuration;

namespace SpecDrill.Infrastructure.Configuration
{
    public class ConfigurationManager
    {
        private const string ConfigurationFileName = "specDrillConfig.json";
        protected static ILog Log = LogManager.GetLogger(typeof(ConfigurationManager));

        public static readonly Settings Settings;
        static ConfigurationManager()
        {
            Settings = Load();
        }

        public static Settings Load(string jsonConfiguration = null)
        {
            if (string.IsNullOrWhiteSpace(jsonConfiguration))
            {
                Log.InfoFormat("Searcing Configuration file {0}...", ConfigurationFileName);
                var configurationPaths = FindConfigurationFile(AppDomain.CurrentDomain.BaseDirectory);
                
                var configurationFilePath = configurationPaths.Item1;
                var log4netConfigFilePath = Path.Combine(configurationFilePath, "log4net.config");

                var log4NetConfig = new FileInfo(log4netConfigFilePath);

                XmlConfigurator.ConfigureAndWatch(log4NetConfig);

                var jsonConfigurationFilePath = configurationPaths.Item2;
                
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

        private static Tuple<string, string> FindConfigurationFile(string folder)
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
                        return Tuple.Create(folder, result);
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
