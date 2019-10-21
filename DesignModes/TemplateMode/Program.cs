using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMode
{
    class Program
    {
        static void Main(string[] args)
        {
            TempLidar tl = new TempLidar();
            tl.TemplateFunction();
            Console.Read();

        }
    }
}
