using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitMode
{
   public class AElement : ElementBase
    {
        public override void Accept(IVisit visit)
        {
            visit.Visit(this);
        }

        public override void Print()
        {
            Console.WriteLine("我是A");
        }
    }
}
