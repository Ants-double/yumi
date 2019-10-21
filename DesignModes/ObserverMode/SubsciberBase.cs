using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverMode
{
    public delegate void NotifyEventHander(object sender);
    class SubsciberBase
    {
        public NotifyEventHander NotifyEvnet;
        public string Flag { get; set; }
        public SubsciberBase(string str)
        {
            Flag = str;

        }

        public void AddObserver(NotifyEventHander neh)
        {
            NotifyEvnet += neh;
        }
        public void RemoveObserver(NotifyEventHander neh)
        {
            NotifyEvnet -= neh;
        }

        public void Update()
        {
            NotifyEvnet?.Invoke(this);
        }
    }
}
