using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverMode
{
    class LidarClient
    {
        public string Name { get; set; }

        public LidarClient(string name)
        {
            Name = name;
        }

        public void ReceiveAndPrint(object obj)
        {
            SubsciberBase sb = obj as SubsciberBase;
            if (null!=sb)
            {
                Console.WriteLine("{0},{1}",sb.Flag,Name);
            }
        }
    }
}
