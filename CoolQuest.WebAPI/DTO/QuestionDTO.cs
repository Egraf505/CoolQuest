using CoolQuest.DbContext.Models;

namespace CoolQuest.backend.DTO
{
    public class QuestionDTO
    {
        public Question Question { get; set; }  
       
        public IEnumerable<AnswerFalse> AnswerFalses { get; set; }
    }
}
