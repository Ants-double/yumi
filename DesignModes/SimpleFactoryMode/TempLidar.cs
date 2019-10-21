using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryMode
{
    class TempLidar : LidarBase
    {
        public override void CreateLidar()
        {
            Console.WriteLine("我是温雷达");
        }
    }
}
