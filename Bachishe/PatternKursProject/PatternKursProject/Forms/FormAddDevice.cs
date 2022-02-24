using PatternKursProject.commandPatt;
using PatternKursProject.devices;
using PatternKursProject.sampleAnalyzer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternKursProject.Forms
{
    public partial class FormAddDevice : Form
    {
        private MonitoringSystem centreMonitor;
        private int numb;
        MainWindow form;
        public FormAddDevice(MonitoringSystem c, int num, MainWindow f)
        {
            InitializeComponent();
            centreMonitor = c;
            form = f;
           
            foreach(var elem in centreMonitor.listAnalysisSystem)
            checkedListBox1.Items.Add("Система №"+elem.getAccountNumber());

            if (num > 0)
            { checkedListBox1.SetItemChecked(num, true);
                numb = num;
            }
        }
      
 

        private void button1_Click(object sender, EventArgs e)
        {
            if (numb < 0)
            {
                MessageBox.Show("Вы не выбрали систему анализа, в которую хотите добавить измерительное устройство.");
                return;
            }
            List<MeasuringDevice> list = new List<MeasuringDevice>();
            if (checkedListBox2.GetItemChecked(0))
                list.Add(new Thermometer(20));

            if (checkedListBox2.GetItemChecked(1))
                list.Add(new Barometer(760));

            if (checkedListBox2.GetItemChecked(2))
                list.Add(new Psychrometer(40));

            if (checkedListBox2.GetItemChecked(3))
                list.Add(new Anemometer(1.5));

            if (checkedListBox2.GetItemChecked(4))
                list.Add(new Diffmanometer(3.5));
            if (checkedListBox2.GetItemChecked(5))
                list.Add(new Adapter(new AirSampleAnalysis()));
            if (checkedListBox2.GetItemChecked(6))
                list.Add(new Adapter(new WaterSampleAnalysis()));
            if (checkedListBox2.GetItemChecked(7))
                list.Add(new Adapter(new SoilSampleAnalysis()));
            if(list.Count==0)
            {
                MessageBox.Show("Вы не выбрали измерительное устройство.");
                return;
            }

            centreMonitor.setCommand(new CommandAddDevice(list, numb));
            centreMonitor.executeCommand();
      
            form.button1_Click(sender, e);
        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Если отмечено больше 2 элементов, то снимаем выделение со всех и отмечаем текущий.
            if (checkedListBox1.CheckedItems.Count > 1)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
                checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, true);
                numb = checkedListBox1.SelectedIndex;
            }
        }
    }
}
