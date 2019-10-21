using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightMode
{
    class ConcreterFlyweight : FlyWeight
    {
        private string inNumber;
        public ConcreterFlyweight(string innerState)
        {
            inNumber = innerState;
        }
        public override void Opeartion(int iNumber)
        {
            Console.WriteLine("外部的{0},内部的{1}",iNumber,inNumber);
        }
    }
}
