using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorMode
{
    class StartModule : ModuleBase
    {
        public StartModule(LidarBase ilm) : base(ilm)
        {

        }
        public override bool LidarOperation()
        {
            base.LidarOperation();
            StartLidar();
            return true;
        }

        public void StartLidar()
        {
            Console.WriteLine("雷达可以开开了");
        }
    }
}
