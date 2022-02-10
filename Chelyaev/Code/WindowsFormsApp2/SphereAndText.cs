using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class SphereAndText : UserControl
    {
        public SphereAndText()
        {
            InitializeComponent();
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Amount.Text) >= 10 || Convert.ToInt32(Amount.Text) < 0)
            {
                Amount.Font = new System.Drawing.Font("Algerian", 10);
            }
            else Amount.Font = new System.Drawing.Font("Algerian", 16);
        }
    }
}
