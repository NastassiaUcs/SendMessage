using Newtonsoft.Json;
using System;

namespace SendMessage
{
    public class Bot
    {
        private Config config;
        public Bot()
        {
            config = Config.GetConfig();
        }

        public bool SendMessage(Message message, string parseMode = null)
        {
            try
            {
                string url = "https://api.telegram.org/bot" + config.token + "/sendMessage?chat_id=" + message.user.id + "&text=" + message.text;
                if (!String.IsNullOrEmpty(parseMode))
                {
                    url += "&parse_mode=" + parseMode;
                }
                string json = Web.Request(url);
                dynamic update = JsonConvert.DeserializeObject<dynamic>(json);
                bool ok = update.ok;
                return ok;
            }
            catch
            {
                return false;
            }
        }
    }
}