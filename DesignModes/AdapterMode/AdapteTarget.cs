using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterMode
{
    class AdapteTarget:RealData
    {

        public HistoryData hisdata = new HistoryData();
        public override void RealFunction()
        {
            hisdata.HisrtoryFunction();
        }

    }
}
