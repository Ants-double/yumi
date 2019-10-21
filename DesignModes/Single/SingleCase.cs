using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single
{
    class SingleCase
    {
        private static SingleCase singleObject;
        private static readonly object locker = new object();
        private SingleCase()
        {

        }
        public static SingleCase GetSingle()
        {
            if (null == singleObject)
            {
                lock (locker)
                {
                    singleObject = new SingleCase();

                }
            }
            return singleObject;
        }
    }
}
