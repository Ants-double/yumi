using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeMode
{
    class Program
    {
        static void Main(string[] args)
        {
            LidarBase lidar = new ConcretePrototype("wind");
            LidarBase lidarone = lidar.Clone();
            Console.WriteLine(lidarone.ID);
            Console.WriteLine(lidar.ID);
            Console.Read();
        }
    }
}
