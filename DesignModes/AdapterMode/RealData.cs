using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterMode
{
    class RealData
    {
        public virtual void RealFunction()
        {
            Console.WriteLine("这是实时数据");
        }
    }
}
