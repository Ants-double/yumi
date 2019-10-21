using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderMode
{
    class Director
    {
        public void CreateLidar(BuilderBase builder)
        {
            builder.AddGPS();
            builder.AddLaser();
        }
    }
}
