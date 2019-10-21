using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarategyMode
{
    public class APassAlgorithm : IStrategyBase
    {
        public void CreateAlgorithm()
        {
            Console.WriteLine("A通道算法");
        }
    }
}
