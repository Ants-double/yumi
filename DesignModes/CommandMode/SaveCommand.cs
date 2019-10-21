using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMode
{
    class SaveCommand : CommandBase
    {
        public SaveCommand(ServerReceiver sr):base(sr)
        {

        }
        public override void ActionCommand()
        {
            SR.SaveData();
        }
    }
}
