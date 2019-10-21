using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChain
{
  public abstract  class DealBase
    {
        public DealBase NextDeal { get; set; }
        public string FlagStr { get; set; }
        public DealBase(string str)
        {
            FlagStr = str;
        }
        
        public abstract void DealData(RequestDeal rd);
        
    }
}
