using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderMode
{
  public  class Lidar
    {
        public IList<string> parts = new List<string>();
        public void Add(string str)
        {
            parts.Add(str);
        }
        public void Show()
        {
            foreach (var item in parts)
            {
                Console.WriteLine("已组装好了{0}",item);
            }
            Console.WriteLine("雷达已完成");
        }
    }
}
