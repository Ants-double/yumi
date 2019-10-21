using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeMode
{
    public class LidarBase
    {
        private OperationBase ob;

        public OperationBase OB
        {
            get { return ob; }
            set { ob = value; }
        }

        public virtual void StartLidar()
        {
            ob.StartLidar();
        }

        public virtual void DealLidarData()
        {
            ob.DealLidarData();
        }

        public virtual void StopLidar()
        {
            ob.StopLidar();
        }

    }
}
