using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electronedge
{
    public class Class1
    {
        public async Task<Object> Invoke(object input)
        {
            return Helper.SayHi("Invoke1:" + (string)input);
        }

        public async Task<Object> Invoke2(object input)
        {
            return  Helper.SayHi("Invoke2:" + (string)input);
        }

        static class Helper
        {
            public static string SayHi(string param)
            {
                return ".NET Welcomes " + param;
            }
        }
    }
}
