using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMode
{
    class TempLidar : OperationBase
    {
        public override void DealLidarData()
        {
            Console.WriteLine("温雷达处理数据了");
        }

        public override void StartLidar()
        {
            Console.WriteLine("温雷达开启成功了");
        }

        public override void StopLidar()
        {
            Console.WriteLine("温雷达关机了");
        }
    }
}
