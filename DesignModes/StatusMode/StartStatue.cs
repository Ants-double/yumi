using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusMode
{
    class StartStatue : StatusBase
    {
        public StartStatue(Lidar ld)
        {
            Console.WriteLine("起始");
            lidar = ld;
        }
        public override void CehckStauts()
        {
            Console.WriteLine("开雷达了");
            lidar.SB = new StartedStaue(this);
        }
    }
}
