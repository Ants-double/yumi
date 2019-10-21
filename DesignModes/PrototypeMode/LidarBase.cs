using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeMode
{
  public abstract  class LidarBase
    {
        public string ID { get; set; }

       

        public LidarBase(string id)
        {
            ID = id;
        }
        public abstract LidarBase Clone();
    }
}
