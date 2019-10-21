using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationMode
{
  public abstract  class LidarBase
    {
        public string FlagStr { get; set; }
        public LidarBase(string flag)
        {
            FlagStr = flag;
        }
        public abstract void StartLidar();
        public abstract void StopLidar();
    }
}
