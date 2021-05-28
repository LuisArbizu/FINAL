using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial02PM.Context;
using Parcial02PM.Entities.Questions;
using Parcial02PM.Entities.Specialities;
using Parcial02PM.View;

namespace Parcial02PM
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());

            using (var db = new ClinicContext())
            {
                db.Questions.RemoveRange(db.Questions);

                var quest = new List<Question>()
                {
                    new Question()
                    {
                        Quest = "¿En qué año naciste?"
                    },
                    new Question()
                    {
                        Quest = "¿Cómo se llamó tu primer mascota??"
                    },
                    new Question()
                    {
                        Quest = "¿De qué colegio te graduaste de bachiller?"
                    },
                    new Question()
                    {
                        Quest = "¿Nombre de tu película favorita?"
                    }
                };
                quest.ForEach(q=> db.Add(q));
                db.SaveChanges();
            }
            
            using (var db = new ClinicContext())
            {
                db.Specialities.RemoveRange(db.Specialities);

                var spe = new List<Speciality>()
                {
                    new Speciality()
                    {
                        S = "Medicina general"
                    },
                    new Speciality()
                    {
                        S = "Odontología"
                    },
                    new Speciality()
                    {
                        S = "Psicología"
                    },
                    new Speciality()
                    {
                        S = "Oftalmología"
                    }
                };
                spe.ForEach(s=> db.Add(s));
                db.SaveChanges();
                
            }   
        }
    }  
} 