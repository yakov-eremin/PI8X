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
    public partial class ReferenceBooks : Form
    {
        public ReferenceBooks()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CounteragentsButton_Click(object sender, EventArgs e)
        {
            Form Counteragents = new Counteragents();
            Counteragents.Show();
        }
    }
}
