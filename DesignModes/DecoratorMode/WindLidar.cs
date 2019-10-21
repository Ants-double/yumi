using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorMode
{
    class WindLidar : LidarBase
    {
        public override bool LidarOperation()
        {
            Console.WriteLine("我是一个风雷达");
            return true;
        }
    }
}
