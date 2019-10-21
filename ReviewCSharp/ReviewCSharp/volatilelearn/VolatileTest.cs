using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewCSharp.volatilelearn
{
    class VolatileTest
    {
        public volatile int i;
        public void Test(int _i)
        {
            i = _i;
        }
    }
}
