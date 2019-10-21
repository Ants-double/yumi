using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryMode
{
    class WindLidar : LidarBase
    {
        public override void CreateLidar()
        {
            Console.WriteLine("我是风雷达");
        }
    }
}
