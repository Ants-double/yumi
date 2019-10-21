using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMode
{
    class Program
    {
        static void Main(string[] args)
        {
            LidarBase lb = new LidarInit();
            lb.OB = new WindLidar();
            lb.StartLidar();
            lb.DealLidarData();
            lb.StopLidar();
            Console.WriteLine("操作完成了");
            lb.OB = new TempLidar();
            lb.StartLidar();
            lb.DealLidarData();
            lb.StopLidar();
            Console.WriteLine("操作完成了");
            Console.Read();
           
        }
    }
}
