using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyMode
{
    class Program
    {
        static void Main(string[] args)
        {
            LidarBase lb = new ProxyLidar();
            lb.GetData();
            Console.Read();
        }
    }
}
