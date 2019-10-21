using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightMode
{
    class FlyweightFactory
    {
        public Dictionary<string, FlyWeight> flyList = new Dictionary<string, FlyWeight>();
        public FlyweightFactory()
        {
            flyList.Add("A", new ConcreterFlyweight("A"));
            flyList.Add("B", new ConcreterFlyweight("B"));
        }

        public FlyWeight GetFlyWeight(string key)
        {
            if (flyList.ContainsKey(key))
            {
                return flyList[key] as FlyWeight;
            }
            else
            {
                return null;
            }
            
        }
    }
}
