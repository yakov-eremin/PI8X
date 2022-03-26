using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PatternKursProject.status
{
    class OnStateWithTime : State
    {
        
        private string name = "Работает";
        public void make()
        {
            MonitoringSystem current = MonitoringSystem.getInstance();
            if (current.listAnalysisSystem.Count == 0)
            {
                current.setState(new OnStateWithoutTime());
          
            }
        }
        public string getName()
        { return name; }
    }
}
