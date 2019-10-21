using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFacotry
{
  public abstract  class FactoryBase
    {
        public abstract LidarBase CreatLidar();
        public abstract AirPlaneBase CreatAirPlane();
    }
}
