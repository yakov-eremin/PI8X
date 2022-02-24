using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.commandPatt
{
    class CommandAddSystem : Command
    {
        private AnalysisSystemMethod syst;
        public int execute()
        {
            MonitoringSystem centre = MonitoringSystem.getInstance();
            centre.addAnalysisSystem(syst);
            return syst.getAccountNumber();
        }
        public CommandAddSystem(AnalysisSystemMethod a)
        {
            syst = a;
        }
    }
}
