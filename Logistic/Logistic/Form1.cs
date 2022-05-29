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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TreatiesButton_Click(object sender, EventArgs e)
        {
            Form Treaties = new Treaties();
            Treaties.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReferenceBooksButton_Click(object sender, EventArgs e)
        {
            Form ReferenceBooks = new ReferenceBooks();
            ReferenceBooks.Show();
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            Form Orders = new Orders();
            Orders.Show();
        }
    }
}
