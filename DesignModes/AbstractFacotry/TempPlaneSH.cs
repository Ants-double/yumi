using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class TempPlaneSH : AirPlaneBase
    {
        public override void CreatePlane()
        {
            Console.WriteLine("我是上海的温飞机");
        }
    }
}
