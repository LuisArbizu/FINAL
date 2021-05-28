using System.ComponentModel.DataAnnotations;
using Parcial02PM.Entities.Questions;
using Parcial02PM.Entities.Specialities;
using Parcial02PM.Entities.Users;

namespace Parcial02PM.Entities.Reservations
{
    public class Reservation
    {
        

        [Key]public int IdR { get; set; }
        public string Date {get;set;}
        public string Time {get;set;}
        
        public virtual User User {get; set; }
        public virtual Speciality Speciality {get; set; }

        public Reservation()
        {
            
        }

        public Reservation(string Date, string Time, User User, Speciality Speciality )
        {
            this.Date = Date;
            this.Time = Time;
            this.User = User;
            this.Speciality = Speciality;
        }
        
    }
}