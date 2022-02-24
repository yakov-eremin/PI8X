using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.commandPatt
{
    class CommandDelDev : Command
    {
        private AnalysisSystemMethod syst;
        private int delDev = 0;

        public int execute()
        {
            syst.delDev(delDev);
            return delDev;

        }
        public CommandDelDev(int n, int del)
        {
            MonitoringSystem centre = MonitoringSystem.getInstance();
            syst = centre.listAnalysisSystem[n];
            delDev=del;
        }
    }
}