using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryMode
{
    class Program
    {
        static void Main(string[] args)
        {
            LidarBase lb1 = LidarFactory.CreatLidar("wind");
            lb1.CreateLidar();
            LidarBase lb2 = LidarFactory.CreatLidar("temp");
            lb2.CreateLidar();
            Console.Read();
        }
    }
}
