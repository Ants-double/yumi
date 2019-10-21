using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMode
{
  public abstract  class OperationBase
    {

        public abstract void StartLidar();

        public abstract void DealLidarData();

        public abstract void StopLidar();

    }
}
