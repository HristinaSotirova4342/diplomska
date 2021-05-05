using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Focus5.Models
{
    public class Indexx
    {
        public Object getWeatherForcast()
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=London&appid=0df83017d406530a503e657ccdf34ad6";
            var client = new WebClient();
            var content = client.DownloadString(url);
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<Object>(content);
            return jsonContent;
        }
    }
}