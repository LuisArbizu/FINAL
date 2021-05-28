using System;
using System.Windows.Forms;

namespace Parcial02PM.View
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancelChange_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}