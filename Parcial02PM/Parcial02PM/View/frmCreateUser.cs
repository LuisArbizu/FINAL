using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Parcial02PM.Context;
using Parcial02PM.Entities.Questions;
using Parcial02PM.Entities.Users;

namespace Parcial02PM.View
{
    public partial class FrmCreateUser : Form
    {
        public FrmCreateUser()
        {
            InitializeComponent();
        }


        private void FrmCreateUser_Load(object sender, EventArgs e)
        {
            var db = new ClinicContext();
            List<Question> quests = db.Questions
                .ToList();

            cmbQuestions.DataSource = quests;
            cmbQuestions.DisplayMember = "Quest";
            cmbQuestions.ValueMember = "IdQ";

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool confirm =
                txtFullName.Text.Length > 5 &&
                txtAnsQuest.Text.Length > 4 &&
                txtPass1.Text.Length > 5 &&
                (txtPass1.Text == txtPass2.Text);

            if (confirm) {
                Question qref = new Question();
                qref.IdQ = ((Question) cmbQuestions.SelectedItem).IdQ;
                
                var db = new ClinicContext();
                Question qbdd = db.Set<Question>()
                    .SingleOrDefault(q => q.IdQ == qref.IdQ);

                User nuevo = new User( txtFullName.Text, txtPass1.Text, txtAnsQuest.Text, qbdd);
                
                db.Add(nuevo);
                db.SaveChanges();
                
                MessageBox.Show(text: "Usuario creado exitosamente!", caption: "Clinica UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);   
                this.Hide();
            }
            else
                MessageBox.Show(text: "Datos no validos!", caption: "Clinica UCA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}