using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChain
{
    public class MoreThan : DealBase
    {
        public MoreThan(string str):base(str)
        {

        }
        public override void DealData(RequestDeal rd)
        {
            if (rd.DataLength>15)
            {
                Console.WriteLine("处理了责任人：{0}", FlagStr);
            }
        }
    }
}
