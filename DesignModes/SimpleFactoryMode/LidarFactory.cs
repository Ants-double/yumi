using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryMode
{
    class LidarFactory
    {
        public static LidarBase CreatLidar(string lidarFlag)
        {
            LidarBase lb = null;
            switch (lidarFlag)
            {
                case "wind":
                    lb = new WindLidar();
                    break;
                case "temp":
                    lb = new TempLidar();
                    break;
                default:
                    break;
            }
            return lb;
        }
    }
}
