using System;
using System.Net.Http;

namespace SendMessage
{
    class Web
    {
        static HttpClient client;

        static Web()
        {
            client = new HttpClient();
        }

        public static string Request(string url)
        {
            string data = default;
            try
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        data = content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception e)
            {
                data = default;                
            }
            return data;
        }
    }
}