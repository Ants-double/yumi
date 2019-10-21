using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightMode
{
    class Program
    {
        static void Main(string[] args)
        {
            int exStatue = 10;
            FlyweightFactory factory = new FlyweightFactory();
            FlyWeight fa = factory.GetFlyWeight("A");
            if (null!=fa)
            {
                fa.Opeartion(exStatue);
            }
            FlyWeight fd = factory.GetFlyWeight("D");
            if (null!=fd)
            {

                fd.Opeartion(exStatue);
            }
            else
            {
                ConcreterFlyweight d = new ConcreterFlyweight("D");
                factory.flyList.Add("D", d);

            }
            Console.Read();
        }
    }
}
