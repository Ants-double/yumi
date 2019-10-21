using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterMode
{
    class Program
    {
        static void Main(string[] args)
        {
            RealData rd = new AdapteTarget();
            rd.RealFunction();
            Console.Read();
        }
    }
}
