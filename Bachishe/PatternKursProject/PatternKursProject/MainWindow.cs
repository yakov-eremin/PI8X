using Microsoft.TeamFoundation.WorkItemTracking.Client.Wiql;
using PatternKursProject.commandPatt;
using PatternKursProject.DecoratorAnalysisSystem;
using PatternKursProject.devices;
using PatternKursProject.status;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternKursProject
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// система мониторинга
        /// </summary>
        private MonitoringSystem centreMonitoring;
        private Button currentButton;
        private Form activeForm;
        public MainWindow()
        {
            Directory.CreateDirectory("Report");
            DirectoryInfo dir = new DirectoryInfo("Report");
           
            foreach (FileInfo f in dir.GetFiles())
            {
                f.Delete();
            }
            InitializeComponent();
            centreMonitoring = MonitoringSystem.getInstance();
            label1.Text = "Главная страница";
            btnCloseChildForm.Visible = false;
            textBox1.Text = "20";
            textBox2.Text = centreMonitoring.getState();

        }
        /// <summary>
        /// следим за кнопками, которые открывают новые вкладки
        /// </summary>
        /// <param name="btnSender"></param>
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                   
                    currentButton = (Button)btnSender;
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        /// <summary>
        /// заполнение таблицы систем анализа
        /// </summary>
        private void writeTable()
        {
            dataGridViewSA.Rows.Clear();
            if (centreMonitoring.listAnalysisSystem.Count > 0)
            {
                int count = centreMonitoring.listAnalysisSystem.Count;
                for (int i = 0; i < count; i++)
                {
                    dataGridViewSA.Rows.Add();
                    dataGridViewSA.Rows[i].Cells[0].Value = centreMonitoring.listAnalysisSystem[i].getAccountNumber();
                    dataGridViewSA.Rows[i].Cells[1].Value = centreMonitoring.listAnalysisSystem[i].getTypeOfSystem();
                    dataGridViewSA.Rows[i].Cells[2].Value = "Открыть";
                    dataGridViewSA.Rows[i].Cells[3].Value = "Удалить";
                }
            }
        }

        /// <summary>
        /// открываю вкладки
        /// </summary>
        /// <param name="childForm"></param>
        /// <param name="btnSender"></param>
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelWorkZone.Controls.Add(childForm);
            this.panelWorkZone.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }
        /// <summary>
        /// по нажатию открываю вкладку добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormAddAS(centreMonitoring, this), sender);
        }
        /// <summary>
        /// закрываю внешние вкладки, возврат на главную
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            label1.Text = "Главная страница";
            currentButton = null;
            btnCloseChildForm.Visible = false;
            writeTable();
            textBox2.Text = centreMonitoring.getState();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            btnCloseChildForm_Click(sender, e);
        }

    
        /// <summary>
        /// нажали на кнопку в таблице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewSA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridViewSA.Columns[e.ColumnIndex].Name)
            {
                case "open":
                    {
                        
                        OpenChildForm(new Forms.AnalisSystemForm(centreMonitoring, e.RowIndex), new Button());
                      //  MessageBox.Show("Данные будут удалены безвозвратно. Вы уверены?", "Выбрана строка № " + e.RowIndex, MessageBoxButtons.OKCancel);
                        break;
                    }
                case "del":
                    {
                        if (timer1.Enabled == true && centreMonitoring.listAnalysisSystem.Count == 1)
                        {
                            timer1.Stop();
                            
                        }
                        centreMonitoring.setCommand(new CommandDelSystem(e.RowIndex));
                        centreMonitoring.executeCommand();
                        centreMonitoring.changeState();
                        textBox2.Text = centreMonitoring.getState();
                        writeTable();
                        
                        break;
                    }

            }
        }

  /// <summary>
  /// открываю вкладку добавления устройств
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if(centreMonitoring.listAnalysisSystem.Count==0)
                MessageBox.Show("К сожалению нет систем анализа, куда можно было бы добавить устройство. Добавте сначала систему анализа. ");
            else
            OpenChildForm(new Forms.FormAddDevice(centreMonitoring, -1, this), sender);
        }

        /// <summary>
        /// открываю папку с отчетами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = System.IO.Path.Combine(Application.StartupPath, @"Report");
                ofd.DefaultExt = "*.xls;*.xlsx";
                ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
                ofd.Title = "Выберите документ Excel";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Process.Start(ofd.FileName);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
        /// <summary>
        /// запускаю мониторинг
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
           
            if (button6.Text == "Запустить мониторинг")
            {
                button6.Text = "Остановить мониторинг";
                textBox1.ReadOnly = true;
                int time = 20;
                if (textBox1.Text != "")
                    time = Convert.ToInt32(textBox1.Text);
                timer1.Interval = 60000*time;
                State s = centreMonitoring.changeState();
                if (s.getName() == "Работает")
                    timer1.Start();
                
            }
            else
            {
                button6.Text = "Запустить мониторинг";
                textBox1.ReadOnly = false;
                timer1.Stop();
                centreMonitoring.setState(new OffState());
            }

            textBox2.Text = centreMonitoring.getState();
        }
        /// <summary>
        /// ограничиваю содержимое текстбокса цифрами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
 char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                if (!(Char.IsDigit(e.KeyChar)))
                {
                    if (e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        /// <summary>
        /// мониторинг по таймеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            (new System.Threading.Thread(delegate () { 
                centreMonitoring.getMeasurement(); 
            })).Start();

        }
    
    }

}
