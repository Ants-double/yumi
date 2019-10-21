using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorMode
{
  public abstract  class ModuleBase: LidarBase
    {
        private LidarBase lidarModel;
        public ModuleBase(LidarBase ilm)
        {
            lidarModel = ilm;
        }
        public override bool LidarOperation()
        {
          return  lidarModel.LidarOperation();
        }
    }
}
