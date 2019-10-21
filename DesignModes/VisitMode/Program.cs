using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitMode
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStruct objectstrut = new ObjectStruct();
            foreach (var item in objectstrut.Elements)
            {
                item.Accept(new CreateVisitor());
            }
            Console.Read();
        }
    }
}
