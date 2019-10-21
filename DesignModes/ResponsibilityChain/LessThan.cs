using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChain
{
    public class LessThan : DealBase
    {
        public LessThan(string str):base(str)
        {

        }
        public override void DealData(RequestDeal rd)
        {
            if (rd.DataLength<15)
            {
                Console.WriteLine("小于15不做处理责任人：{0}",FlagStr);

            }
            else
            {
                Console.WriteLine("大于要做处理了");
                NextDeal.DealData(rd);
            }
        }
    }
}
