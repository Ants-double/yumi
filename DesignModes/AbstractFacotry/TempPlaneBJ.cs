using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class TempPlaneBJ : AirPlaneBase
    {
        public override void CreatePlane()
        {
            Console.WriteLine("我是北京的温飞机");
        }
    }
}
