using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SendMessage
{
    public class Config
    {
        public string token;
        public List<int> ids;

        private static Config config;

        public static Config GetConfig()
        {
            if (config == null)
            {
                CreateConfig();
                return config;
            }
            else
            {
                return config;
            }
        }

        private static void CreateConfig()
        {
            var filename = @"./config.json";
            try
            {
                using (StreamReader r = new StreamReader(filename))
                {
                    string json = r.ReadToEnd();
                    config = JsonConvert.DeserializeObject<Config>(json);
                }
                config.ids = config.ids.Distinct().ToList<int>();
            }
            catch
            {
                config = null;
            }
        }
    }
}