using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMode
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryBase windFactory = new WindFactory();
            FactoryBase tempFactory = new TempFactory();
            LidarBase wind = windFactory.CreateLidarFactory();
            LidarBase temp = tempFactory.CreateLidarFactory();
            wind.CreateLidar();
            temp.CreateLidar();
            Console.Read();
        }
    }
}
