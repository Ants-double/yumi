using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitMode
{
  public  interface IVisit
    {
        void Visit(AElement a);
        void Visit(BElement b);
    }
}
