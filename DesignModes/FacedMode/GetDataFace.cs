using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacedMode
{
    class GetDataFace
    {
        private HistoryData hd;
        private RealData rd;
        public GetDataFace()
        {
            hd = new HistoryData();
            rd = new RealData();
        }

        public void GetData()
        {
            hd.GetHistory();
            rd.GetRealData();
        }
    }
}
