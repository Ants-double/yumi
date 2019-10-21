using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorMode
{
    class Program
    {
        static void Main(string[] args)
        {
            LidarBase lidar = new WindLidar();
            ModuleBase lidarStartModule = new StartModule(lidar);
            lidarStartModule.LidarOperation();
            ModuleBase lidarStartPlotModule = new PlotModule(lidarStartModule);
            lidarStartPlotModule.LidarOperation();
            ModuleBase lidarStartPlotStopModule = new StopModule(lidarStartPlotModule);
            lidarStartPlotStopModule.LidarOperation();
            Console.Read();
        }
    }
}
