using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorMode
{
    class StopModule : ModuleBase
    {
        public StopModule(LidarBase ilm) : base(ilm)
        {

        }

        public override bool LidarOperation()
        {
            base.LidarOperation();
            StopLidar();
            return true;
        }

        public void StopLidar()
        {
            Console.WriteLine("我可以关雷达了");
        }
    }
}
