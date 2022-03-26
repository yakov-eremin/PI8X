using PatternKursProject.devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternKursProject.commandPatt
{
    class CommandAddDevice:Command
    {
        private AnalysisSystemMethod syst;
        private List<MeasuringDevice> list;
        public int execute()
        {
            if (list != null)
            {
                foreach (var dev in list)
                    syst.addDevice(dev);
                MessageBox.Show("Устройства добавлены");
            }
            return syst.getAccountNumber();
        }
        public CommandAddDevice(List<MeasuringDevice> a, int n)
        {
            MonitoringSystem centre = MonitoringSystem.getInstance();
            list = a;
            syst = centre.listAnalysisSystem[n];
        }
    }
}
