using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class TempFactoryBJ : FactoryBase
    {
        public override AirPlaneBase CreatAirPlane()
        {
            return new TempPlaneBJ();
        }

        public override LidarBase CreatLidar()
        {
            return new TempLidarBJ();
        }
    }
}
