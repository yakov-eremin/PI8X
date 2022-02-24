using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.status
{
    public interface State
    {
        void make();
        string getName();
    }
}
