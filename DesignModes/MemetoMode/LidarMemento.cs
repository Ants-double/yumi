using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemetoMode
{
    class LidarMemento
    {
        public List<Lidar> LidarList;
        public LidarMemento(List<Lidar> lidars)
        {
            LidarList = lidars;
        }
    }
}
