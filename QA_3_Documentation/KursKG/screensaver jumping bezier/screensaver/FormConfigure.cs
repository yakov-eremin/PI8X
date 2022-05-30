using System;
using System.Windows.Forms;

namespace screensaver
{
    /// <summary>
    /// Форма с настройками.
    /// </summary>
    public partial class FormConfigure : Form
    {
        public FormConfigure()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.QuantLines = Convert.ToInt32(comboBox1.SelectedItem);
            Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.QuantDots = Convert.ToInt32(comboBox2.SelectedItem);
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.QuantLines = Convert.ToInt32(comboBox1.SelectedItem);
            Properties.Settings.Default.QuantDots = Convert.ToInt32(comboBox2.SelectedItem);
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
