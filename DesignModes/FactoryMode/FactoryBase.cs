using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMode
{
   public abstract class FactoryBase
    {
        public abstract LidarBase CreateLidarFactory();
    }
}
