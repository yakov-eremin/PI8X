using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternKursProject.commandPatt
{
    class CommandDelSystem : Command
    {

        private int del=0;
        public int execute()
        {MonitoringSystem centre = MonitoringSystem.getInstance();
            centre.delAnalysisSystem(del);
            return del;

        }
        public CommandDelSystem(int n)
        {
            
            del = n;
        }
    }
}

