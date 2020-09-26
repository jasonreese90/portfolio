using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace ShoutWatch
{
    public class ShoutWatcher
    {

        private async Task<String> DownloadHtmlAsync(string url)
        {
            return await DownloadHtmlAsync(url, null);
        }

        private async Task<string> DownloadHtmlAsync(string url, CookieContainer cookies)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = cookies;
            WebResponse response = await request.GetResponseAsync();

            StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
         
            return result;
        }

        
        private JsonObject ParseShoutJson(string html)
        {
            int startIndex = html.IndexOf("var Shouts = ") + 14;
            int endIndex = html.IndexOf("};", startIndex);

            string json = html.Substring(startIndex, endIndex - startIndex);

            return JsonObject.Parse("{" + json + "}");
            }


        public async Task<Shout[]> GetShoutsAsync(string url, Server server)
        {
            CookieContainer cookies = new CookieContainer();
           
         
            cookies.Add(new Uri(url), new Cookie("sid", server.ToString()));
            cookies.Add(new Uri(url), new Cookie("key", "1U1qaWYHSTwHu56hn1ykj4XuHL9waXj5gp4dgD2uL6ZF9722Ys"));
            cookies.Add(new Uri(url), new Cookie("username", "Kunihiro"));
      
            string html = await DownloadHtmlAsync(url,cookies);
            html = await DownloadHtmlAsync(url, cookies);
            JsonObject shoutObject = ParseShoutJson(html);


            JsonArray shoutArray = shoutObject.GetNamedArray("shouts");

            List<Shout> shouts = new List<Shout>();
            
            foreach(IJsonValue x in shoutArray)
            {

                JsonObject j = x.GetObject();
                Shout s = new Shout();
                s.Zone = (int)j.GetNamedNumber("zone");
                s.Timestamp = (long)j.GetNamedNumber("timestamp");
                s.Character = j.GetNamedString("character");
                s.Mode = j.GetNamedString("mode");
                s.Message = j.GetNamedString("message");

                shouts.Add(s);
            }

            return shouts.ToArray();
        }

        //private async Task<Shout[]> GetNewShoutsAsync()
        //{

        //}
    }
}
