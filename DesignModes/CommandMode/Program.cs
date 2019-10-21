using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMode
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerReceiver sr = new ServerReceiver();
            CommandBase cb = new SaveCommand(sr);
            CommandInvoke ci = new CommandInvoke(cb);
            ci.DoCommand();
            Console.Read();
        }
    }
}
