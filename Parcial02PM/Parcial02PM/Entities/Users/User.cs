using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Windows.Forms;
using Parcial02PM.Entities.Questions;

namespace Parcial02PM.Entities.Users
{
    public class User
    {
        

        [Key]public int CardId { get; set; }
        public string FullName { get; set; }
        public string Password {get;set;}
        public string Answer { get; set; }
        

        public virtual Question Question {get; set; }

        public User()
        {
            
        }

        public User(string FullName, string Password, string Answer, Question Question)
        {
            
            this.FullName = FullName;
            this.Password = Password;
            this.Answer = Answer;
            this.Question = Question;
        }
    }
}