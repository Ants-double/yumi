using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsibilityChain
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestDeal rdmin = new RequestDeal(7);
            RequestDeal rdmax = new RequestDeal(17);
            DealBase dbmin = new LessThan("小于15");
            DealBase dbmax = new MoreThan("大于15");
            dbmin.NextDeal = dbmax;
            dbmin.DealData(rdmin);
            dbmin.DealData(rdmax);
            Console.Read();
        }
    }
}
