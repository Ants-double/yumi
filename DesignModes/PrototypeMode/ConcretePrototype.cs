using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeMode
{
    class ConcretePrototype : LidarBase
    {
        public ConcretePrototype(string id):base(id)
        {

        }

        public override LidarBase Clone()
        {
            return (LidarBase) this.MemberwiseClone();
        }
    }

}
