using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorMode
{
    class Program
    {
        static void Main(string[] args)
        {
            TempLidar temp = new TempLidar();
            WindLidar wind = new WindLidar();
            MddiatorBase mediator = new LidarMediator(temp,wind);
            temp.Writelog(mediator);
            Console.Read();
        }
    }
}
