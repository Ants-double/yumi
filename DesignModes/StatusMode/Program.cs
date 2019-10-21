using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusMode
{
    class Program
    {
        static void Main(string[] args)
        {
            Lidar ld = new Lidar();
            ld.startLidar();
            ld.CloseLidar();
            Console.Read();
        }
    }
}
