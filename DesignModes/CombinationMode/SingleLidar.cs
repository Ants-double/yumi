using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationMode
{
    class SingleLidar : LidarBase
    {
        public SingleLidar(string  str):base(str)
        {

        }
        public override void StartLidar()
        {
            Console.WriteLine("开简单的雷达{0}",FlagStr);
        }

        public override void StopLidar()
        {
            Console.WriteLine("关简单的雷达{0}",FlagStr);

        }
    }
}
