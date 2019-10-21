using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMode
{
    class WindFactory : FactoryBase
    {
        public override LidarBase CreateLidarFactory()
        {
            return new WindLidar();
        }
    }
}
