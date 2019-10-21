using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class TempFactorySH : FactoryBase
    {
        public override AirPlaneBase CreatAirPlane()
        {
            return new TempPlaneSH();
        }

        public override LidarBase CreatLidar()
        {
           return new TempLidarSH();
        }
    }
}
