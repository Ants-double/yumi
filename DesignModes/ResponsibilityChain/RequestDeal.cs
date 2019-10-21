using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChain
{
  public  class RequestDeal
    {
        public int DataLength { get; set; }
        public RequestDeal(int length)
        {
            DataLength = length;
        }
    }
}
