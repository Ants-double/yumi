using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationMode
{
    class ManyLidar : LidarBase
    {
        private List<LidarBase> manyLidar = new List<LidarBase>();
        public ManyLidar(string str) : base(str)
        {

        }
        public override void StartLidar()
        {
            Console.WriteLine("开复杂的雷达{0}", FlagStr);

            foreach (var item in manyLidar)
            {
                item.StartLidar();
            }

        }

        public override void StopLidar()
        {
            Console.WriteLine("关复杂的雷达{0}", FlagStr);

            foreach (var item in manyLidar)
            {
                item.StopLidar();
            }
        }
        public void AddLidar(LidarBase lb)
        {
            manyLidar.Add(lb);
        }
        public void RemoveLidar(LidarBase lb)
        {
            manyLidar.Remove(lb);
        }

        public void OtherOpeartion()
        {

            Console.WriteLine("这是我特有的操作{0}",FlagStr);
        }
    }
}
