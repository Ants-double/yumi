using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyMode
{
    class TempLidar : LidarBase
    {
        public override void GetData()
        {
            Console.WriteLine("这是温雷达数据");
        }
    }
}
