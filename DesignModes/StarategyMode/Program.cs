using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarategyMode
{
    class Program
    {
        static void Main(string[] args)
        {
            IStrategyBase isb = new APassAlgorithm();
            PassAlgorithm pa = new PassAlgorithm(isb);
            pa.GetPassValue();
            pa = new PassAlgorithm(new BPassAlgorithm());
            pa.GetPassValue();
            Console.Read();
        }

    }
}
