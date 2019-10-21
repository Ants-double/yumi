using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderMode
{
  public abstract  class BuilderBase
    {
        public abstract void AddGPS();
        public abstract void AddLaser();
        public abstract Lidar GetLidar();
    }
}
