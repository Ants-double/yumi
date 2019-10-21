using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitMode
{
    public class CreateVisitor : IVisit
    {
        public void Visit(AElement a)
        {
            a.Print();
        }

        public void Visit(BElement b)
        {
            b.Print();
        }
    }
}
