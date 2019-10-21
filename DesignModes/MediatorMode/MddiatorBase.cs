using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorMode
{
  public abstract  class MddiatorBase
    {
        protected LidarBase tempLidar;
        protected LidarBase windLidar;
        public MddiatorBase(LidarBase temp,LidarBase wind)
        {
            tempLidar = temp;
            windLidar = wind;
        }
        public abstract void WriteAll();
      
    }
}
