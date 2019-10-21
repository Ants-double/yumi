using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
    class WindFactoryBJ : FactoryBase
    {
        public override AirPlaneBase CreatAirPlane()
        {
            return new WindAriPlaneBJ();
        }

        public override LidarBase CreatLidar()
        {
            return new WindLidarBJ();
        }
    }
}
