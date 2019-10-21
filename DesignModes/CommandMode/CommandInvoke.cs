using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMode
{
    class CommandInvoke
    {
        private CommandBase CD;
        public CommandInvoke(CommandBase cb)
        {
            CD = cb;
        }
        public void DoCommand()
        {
            CD.ActionCommand();
        }
    }
}
