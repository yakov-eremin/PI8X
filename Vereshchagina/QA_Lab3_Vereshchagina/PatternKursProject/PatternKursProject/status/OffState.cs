using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.status
{/// <summary>
/// состояние отключенной системы
/// </summary>
    class OffState:State
    {
        private string name = "Не работает";
        public void make()
        {
            MonitoringSystem current = MonitoringSystem.getInstance();
            if (current.listAnalysisSystem.Count == 0)
                current.setState(new OnStateWithoutTime());
            else current.setState(new OnStateWithTime());
        }
        public string getName()
        { return name; }
    }
}
