using System;

namespace SendMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Bot bot = new Bot();
            Config config = Config.GetConfig();

            foreach (int id in config.ids)
            {
                Message message = new Message
                {
                    user = new User { id = id },
                    text = "you text"
                };
                bool res = bot.SendMessage(message);
                if (res)
                {
                    count++;                    
                }                
            }            
            Console.WriteLine("Всего отправили = {0}", count);
            Console.ReadLine();
        }
    }
}