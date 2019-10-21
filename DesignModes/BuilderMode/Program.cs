using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderMode
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            BuilderBase builder = new ConcreteBuilderOne();
            director.CreateLidar(builder);
            Lidar lidar = builder.GetLidar();
            lidar.Show();
            Console.Read();
        }
    }
}
