using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemetoMode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lidar> lidars = new List<Lidar>()
            {
                new Lidar{Name="wind",DataNumber="1"},
                new Lidar{Name="temp",DataNumber="2"},
                new Lidar{Name="gosail",DataNumber="3"}
            };
            LidarOwner lidarowner = new LidarOwner(lidars);
            lidarowner.Show();
            Taker lidarTaker = new Taker();
            lidarTaker.lidarMemento = lidarowner.CreateMemento();
            lidarowner.LidarList.RemoveAt(1);
            lidarowner.Show();
            lidarowner.RestoreMemento(lidarTaker.lidarMemento);
            lidarowner.Show();
            Console.Read();
        }
    }
}
