using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMode
{
    public abstract class LidarBase
    {

        public void TemplateFunction()
        {
            StartLidar();
            StartCollectionData();
            CloseLidar();

        }
        public virtual void StartLidar()
        {
            Console.WriteLine("开始开雷达");
        }
        public virtual void StartCollectionData()
        {
            Console.WriteLine("开始采数");
        }
        public virtual void CloseLidar()
        {
            Console.WriteLine("开始关雷达");
        }
    }
}
