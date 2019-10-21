using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverMode
{
    class Program
    {
        static void Main(string[] args)
        {
            SubsciberBase Sb = new LidarSubscriber("Lidar");
            LidarClient ld1 = new LidarClient("client1");
            LidarClient ld2 = new LidarClient("client2");
            LidarClient ld3 = new LidarClient("client3");

            Sb.AddObserver(new NotifyEventHander(ld1.ReceiveAndPrint));
            Sb.AddObserver(new NotifyEventHander(ld2.ReceiveAndPrint));
            Sb.AddObserver(new NotifyEventHander(ld3.ReceiveAndPrint));

            Sb.Update();
            Console.WriteLine("*****************");
            Sb.RemoveObserver(ld2.ReceiveAndPrint);
            Sb.Update();
            Console.Read();
        }
    }
}
