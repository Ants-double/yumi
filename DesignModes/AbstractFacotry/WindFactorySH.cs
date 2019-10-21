using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class WindFactorySH : FactoryBase
    {
        public override AirPlaneBase CreatAirPlane()
        {
            return new WindAirPlaneSH();
        }

        public override LidarBase CreatLidar()
        {
            return new WindLidarSH();
        }
    }
}
