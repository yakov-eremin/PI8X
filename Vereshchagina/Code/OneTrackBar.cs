using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGRastr
{
    public partial class OneTrackBar : Form
    {
        private MainWindowForm _parent;
        private MainWindowForm.TransInfo _info;
        public OneTrackBar(MainWindowForm parent, MainWindowForm.TransInfo info)
        {
            _info = info;
            _parent = parent;
            InitializeComponent();
        }

        private void OneTrackBar_Load(object sender, EventArgs e)
        {
            this.TransformationParametrTrackBar.Maximum = _info.max;
            this.TransformationParametrTrackBar.Minimum = _info.min;
            ResetTrackBar();
            this.transformationParam.Text = _info.Label;
            _info.tr.ChangeKoeff(_info.getv(_info.current));
            _parent.transformCopy(_info.tr);
        }

        private void ResetTrackBar()
        {
            this.TransformationParametrTrackBar.Value = _info.current;
            ParametrValue.Text = _info.getv(this.TransformationParametrTrackBar.Value).ToString();
        }
        private void TransformationParametrTrackBar_Scroll(object sender, EventArgs e)
        {
            double value = _info.getv(this.TransformationParametrTrackBar.Value);
            this.ParametrValue.Text = value.ToString();
            _info.tr.ChangeKoeff(value);
            _parent.transformCopy(_info.tr);

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ResetTrackBar();
            _parent.SaveTransformations();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ResetTrackBar();
            _parent.RollbackTransformations();
        }
    }
}
