using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PatternKursProject.status
{/// <summary>
/// состояние включенной системы, но не имеющей систем анализа, находится в режиме ожидания
/// </summary>
    class OnStateWithoutTime : State
    {
        
        private string name = "Ожидает";
        public void make()
        {
            MonitoringSystem current = MonitoringSystem.getInstance();
            if (current.listAnalysisSystem.Count > 0)
                current.setState(new OnStateWithTime());
        }
        public string getName()
        { return name; }
    }
}
