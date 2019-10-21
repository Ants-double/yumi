using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarategyMode
{
    public class BPassAlgorithm : IStrategyBase
    {
        public void CreateAlgorithm()
        {
            Console.WriteLine("B通道算法");
        }
    }
}
