using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Parcial02PM.Context;
using Parcial02PM.Entities.Reservations;
using Parcial02PM.Entities.Specialities;
using Parcial02PM.Entities.Users;


namespace Parcial02PM.View
{
    public partial class FrmPrincipal : Form
    {
        private User FullName { get; set; }
        public FrmPrincipal(User FullName)
        {
            InitializeComponent();
            
            this.FullName = FullName;
        }

        

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Bienvenido: " + FullName;
            updateReservations();
            
            var db = new ClinicContext();
            cmbSpecialities.DataSource = db.Specialities.ToList();
            cmbSpecialities.DisplayMember = "S";
            cmbSpecialities.ValueMember = "IdS"; 
            
            var listaUsers = db.Users
                .Include(u=> u.Question)
                .OrderBy(c => c.CardId)
                .ToList();
        }

        private void updateReservations()
        {   
            var db = new ClinicContext();
            var listaReservations = db.Reservations
                .Include(r=> r.IdR)
                .Include(r => r.User) 
                .Include(r => r.Speciality)
                .OrderBy(r => r.IdR)
                .ToList();
            
            var result = listaReservations.Where(
                r => r.User.FullName.Equals(FullName.CardId)
            ).ToList();
            List<Speciality> listaSpecialities = new List<Speciality>();
            foreach (Reservation r in result)
            {
                listaSpecialities.Add(r.Speciality);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaSpecialities;
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            
            Speciality sref = (Speciality) cmbSpecialities.SelectedItem;

            var db = new ClinicContext();
            Speciality sbdd = db.Set<Speciality>()
                .SingleOrDefault((s => s.IdS == sref.IdS));
            
            User ubdd = db.Set<User>()
                .SingleOrDefault((u => u.CardId == u.CardId));

            Reservation r = new Reservation(txtDate.Text, txtHour.Text, ubdd, sbdd); 
            db.Add(r);
            db.SaveChanges();
            
            
            MessageBox.Show(text: "Reservacion Hecha!", caption: "Clinica UCA",
                MessageBoxButtons.OK, MessageBoxIcon.Information);   
            this.Hide(); 
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
