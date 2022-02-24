using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.Flyweight
{
    class FlyweightFactory
    {
        static List<FlyweightData> list = new List<FlyweightData>();

        static public FlyweightData createFlyweight(SourceType t)
        {
            if (list.Count != 0)
                foreach (var elem in list)
                    if (t == elem.getTypeOfSystem())
                        return elem;
            return new FlyweightData(t);
        }
     
    }
}
