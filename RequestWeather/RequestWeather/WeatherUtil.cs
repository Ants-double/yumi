using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace RequestWeather
{
    class WeatherUtil
    {
        private Dictionary<String, String> cityDic = new Dictionary<string, string>();

        public WeatherUtil()
        {
            readCityCode();
        }
        private void readCityCode()
        {
            StreamReader stream = new StreamReader(Path.Combine(Environment.CurrentDirectory, "cityCode.txt"),
                Encoding.Default);
            String line;
            while ((line = stream.ReadLine()) != null)
            {
                try
                {
                    cityDic.Add(line.Split("=")[1], line.Split("=")[0]);
                }
                catch (Exception)
                {

                   
                }
            }
        }

        public WeatherInfo getWeather(String cityName)
        {
            WeatherInfo weather = null;
            try
            {
                String cityCode = cityDic[cityName];
                String weatherUrl = $"http://www.weather.com.cn/data/sk/{cityCode}.html";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(weatherUrl);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                weather = (WeatherInfo)JsonConvert.DeserializeObject<WeatherInfo>(retString);
               


            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.ToString());
               
            }
            return weather;
        }
    }
}
