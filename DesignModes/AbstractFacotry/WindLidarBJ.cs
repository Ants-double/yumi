using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class WindLidarBJ : LidarBase
    {
        public override void CreateLidar()
        {
            Console.WriteLine("我是北京的风雷达");
        }
    }
}
