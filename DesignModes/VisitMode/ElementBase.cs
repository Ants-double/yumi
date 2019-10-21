using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitMode
{
   public abstract  class ElementBase
    {
        public abstract void Accept(IVisit visit);
        public abstract void Print();
    }
}
