using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusMode
{
    class StartedStaue : StatusBase
    {
        public StartedStaue(StatusBase sb)
        {
            
           
        }
        public override void CehckStauts()
        {
            Console.WriteLine("完成了");
         
        }
    }
}
