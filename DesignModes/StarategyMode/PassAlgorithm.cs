using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarategyMode
{
    public class PassAlgorithm
    {
        IStrategyBase isb;
        public PassAlgorithm(IStrategyBase ib)
        {
            isb = ib;
        }

        public void GetPassValue()
        {
            isb.CreateAlgorithm();
        }
    }
}
