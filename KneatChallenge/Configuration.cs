using Microsoft.Extensions.Configuration;
using System.IO;

namespace KneatChallenge.ConsoleApp
{
    //singleton
    public sealed class Configuration
    {
        private static Configuration _instance = null;
        private IConfiguration config;


        private Configuration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");
            config = builder.Build();
        }

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }

                return _instance;
            }
        }

        public string getAppSettingValue(string key)
        {
            return config[key];
        }

         
    }
}
