using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacedMode
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDataFace gdf = new GetDataFace();
            gdf.GetData();
            Console.Read();
        }
    }
}
