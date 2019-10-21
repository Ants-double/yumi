using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMode
{
    class TempLidar:LidarBase
    {
        public override void StartLidar()
        {
            base.StartLidar();
            Console.WriteLine("开始开温雷达");
        }
    }
}
