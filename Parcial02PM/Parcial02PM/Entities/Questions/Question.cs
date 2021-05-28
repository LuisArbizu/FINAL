using System.ComponentModel.DataAnnotations;

namespace Parcial02PM.Entities.Questions
{
    public class Question
    {
       
       [Key]public int IdQ { get; set; }
        public string Quest { get; set; }

        public Question()
        {
            
        }
        
        public Question(string Quest)
        {
            this.Quest = Quest;
        }
    }
}