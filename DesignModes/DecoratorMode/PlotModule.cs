using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorMode
{
   public class PlotModule:ModuleBase
    {
        public PlotModule(LidarBase ilm):base(ilm)
        {

        }
        public override bool LidarOperation()
        {
             base.LidarOperation();
            AddPlot();
            return true;
        }
      
        public void AddPlot()
        {
            Console.WriteLine("我可以绘图了");
        }
    }
}
