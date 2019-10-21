using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyMode
{
    class ProxyLidar : LidarBase
    {
        TempLidar tl = null;
        public override void GetData()
        {
            Console.WriteLine("代理之前可以做的操作");
            if (null==tl)
            {
                tl = new TempLidar();

            }
            tl.GetData();
            Console.WriteLine("代理之后可以做的操作");
        }
    }
}
