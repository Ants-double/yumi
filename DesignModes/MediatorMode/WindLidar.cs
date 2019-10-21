using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorMode
{
    class WindLidar : LidarBase
    {
        public override void Writelog(MddiatorBase mediator)
        {
            mediator.WriteAll();
        }
    }
}
