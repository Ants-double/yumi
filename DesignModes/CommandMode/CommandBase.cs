using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMode
{
  public abstract  class CommandBase
    {
        protected ServerReceiver SR;
        public CommandBase(ServerReceiver sr)
        {
            SR = sr;
        }

        public abstract void ActionCommand();  

    }
}
