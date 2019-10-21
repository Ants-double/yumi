using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderMode
{
    class ConcreteBuilderOne : BuilderBase
    {
        Lidar lidar = new Lidar();
        public override void AddGPS()
        {
            lidar.Add("GPS");
        }

        public override void AddLaser()
        {
            lidar.Add("Laser");
        }

        public override Lidar GetLidar()
        {
            return lidar;
        }
    }
}
