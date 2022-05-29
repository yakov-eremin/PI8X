using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logistic
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }

        private void StartDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (StartDateCheckBox.Checked == false)
            {
                StartDateListBox1.Enabled = false;
                StartDateListBox2.Enabled = false;
            }
            else
            {
                StartDateListBox1.Enabled = true;
                StartDateListBox2.Enabled = true;
            }
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            OrderNumberTextBox.Text = "";
            TreatieNumberTextBox.Text = "";
            SummaryTextBox.Text = "";
            AddressTextBox.Text = "";
            StartDateCheckBox.Checked = false;
        }

        private void AddOrderButton_Click(object sender, EventArgs e)
        {
            Form CreateOrder = new CreateOrder();
            CreateOrder.Show();
        }

        private void EditOrderButton_Click(object sender, EventArgs e)
        {
            Form EditOrder = new EditOrder();
            EditOrder.Show();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Form OrderExport = new OrderExport();
            OrderExport.Show();
        }
    }
}
