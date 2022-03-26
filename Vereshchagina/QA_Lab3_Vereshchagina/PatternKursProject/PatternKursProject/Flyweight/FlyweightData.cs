using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.Flyweight
{
    class FlyweightData
    {
        private SourceType typeOfSystem;
        public SourceType getTypeOfSystem() { return typeOfSystem; }
        public FlyweightData(SourceType t)
        {
            typeOfSystem = t;
        }
    }
}
