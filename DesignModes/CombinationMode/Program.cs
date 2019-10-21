using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationMode
{
    class Program
    {
        static void Main(string[] args)
        {
            ManyLidar ml = new ManyLidar("多服务雷达");
            ml.AddLidar(new SingleLidar("风雷达"));
            ml.AddLidar(new SingleLidar("温雷达"));
            SingleLidar sl = new SingleLidar("个功能雷达风");
            sl.StartLidar();
            sl.StopLidar();
            ml.StartLidar();
            ml.StopLidar();
            ml.OtherOpeartion();
            Console.Read();
        }
    }
}
