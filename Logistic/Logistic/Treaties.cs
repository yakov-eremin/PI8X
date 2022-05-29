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
    public partial class Treaties : Form
    {
        public Treaties()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateTreatieButton_Click(object sender, EventArgs e)
        {
            Form CreateTreatie = new CreateTreatie();
            CreateTreatie.Show();
        }

        private void TreatieRegistryButton_Click(object sender, EventArgs e)
        {
            Form TreatieRegistry = new TreatieRegistry();
            TreatieRegistry.Show();
        }

    }
}
