using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class TempLidarSH : LidarBase
    {
        public override void CreateLidar()
        {
            Console.WriteLine("我是上海的温雷达");
        }
    }
}
