using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusMode
{
   public class Lidar
    {
        public StatusBase SB = null;

        public Lidar()
        {
            SB = new StartStatue(this);
        }
        public void startLidar()
        {
            SB.CehckStauts();
        }
       public void CloseLidar()
        {
            SB.CehckStauts();
        }
    }
}
