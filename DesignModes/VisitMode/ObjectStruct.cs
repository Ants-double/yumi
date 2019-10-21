using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitMode
{
   public class ObjectStruct
    {
        private List<ElementBase> elements = new List<ElementBase>();

        public List<ElementBase> Elements
        {
            get { return elements; }
        }

        public ObjectStruct()
        {
            Random rd = new Random();
            for (int i = 0; i < 10; i++)
            {

                int num = rd.Next(10);
                if (num>5)
                {
                    elements.Add(new AElement());

                }
                else
                {
                    elements.Add(new BElement());
                }
            }
        }
    }
}
