using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Parcial02PM.Context;
using Parcial02PM.Entities.Users;

namespace Parcial02PM.View
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            FrmCreateUser window = new FrmCreateUser();
            window.ShowDialog();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword window = new FrmChangePassword();
            window.ShowDialog();
        }


        private void btnInitSes_Click(object sender, EventArgs e)
        {
            string Name = txtFullName.Text;
            string Pass = txtPassword.Text;
            
            var db = new ClinicContext();
            var listaUsers = db.Users
                .Include(u=> u.Question)
                .OrderBy(c => c.CardId)
                .ToList();
            
            var result = listaUsers.Where(
                o => o.FullName.Equals(txtFullName.Text) &&
                     o.Password.Equals(txtPassword.Text)
            ).ToList();
            
            if (result.Count == 0)
                MessageBox.Show(text: "El usuario no existe!", caption: "Clinica UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                MessageBox.Show(text: "BIENVENIDO!", caption: "Clinica UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmPrincipal window = new FrmPrincipal(result[0]);
                this.Hide();
                window.ShowDialog();
            }
        }
    }
}   