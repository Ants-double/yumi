using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BridgeMode
{
    public class WindLidar : OperationBase
    {
        public override void DealLidarData()
        {
            Console.WriteLine("风雷达处理数据了");
        }

        public override void StartLidar()
        {
            Console.WriteLine("风雷达开启成功了");
        }

        public override void StopLidar()
        {
            Console.WriteLine("风雷达关机成功了");
        }
    }
}
