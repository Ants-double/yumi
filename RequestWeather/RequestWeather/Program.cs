using System;

namespace RequestWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new WeatherUtil();
            while (true)
            {
                Console.WriteLine("请输入查询的城市,并回车");
                String readContent = Console.ReadLine();
                Console.WriteLine($"正在查询{readContent}的天气信息");
                WeatherInfo weatherInfo = temp.getWeather(readContent.Trim());
                if (weatherInfo != null)
                {
                    Console.WriteLine($"查询结果:{weatherInfo.weatherinfo.ToString()}");
                }
                else
                {
                    Console.WriteLine("你查询的城市不存在");
                }
            }
        }
    }
}
