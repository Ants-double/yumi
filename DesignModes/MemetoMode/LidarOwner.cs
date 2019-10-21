using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemetoMode
{
    class LidarOwner
    {
        public List<Lidar> LidarList { get; set; }
        public LidarOwner(List<Lidar> lidars)
        {
            LidarList = lidars;
        }

        public LidarMemento CreateMemento()
        {
            return new LidarMemento(new List<Lidar>(LidarList));
        }

        public void RestoreMemento(LidarMemento memento)
        {
            LidarList = memento.LidarList;
        }
        public void Show()
        {
            foreach (var item in LidarList)
            {
                Console.WriteLine("{0},{1}",item.Name,item.DataNumber);

            }
        }
    }
}
