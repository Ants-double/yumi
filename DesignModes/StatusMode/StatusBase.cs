using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusMode
{
  public abstract  class StatusBase
    {
        public Lidar lidar { get; set; }
        public string LidarStatue { get; set; }
        public abstract void CehckStauts();
    }
}
