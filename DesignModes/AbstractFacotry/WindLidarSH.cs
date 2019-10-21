using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class WindLidarSH : LidarBase
    {
        public override void CreateLidar()
        {
            Console.WriteLine("我是上海的风雷达");
        }
    }
}
