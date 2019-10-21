using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorMode
{
    class LidarMediator : MddiatorBase
    {
        public LidarMediator(LidarBase A,LidarBase B):base(A,B)
        {

        }

        public override void WriteAll()
        {
            Console.WriteLine("这是风雷达");
            Console.WriteLine("这是温雷达");

        }
    }
}
