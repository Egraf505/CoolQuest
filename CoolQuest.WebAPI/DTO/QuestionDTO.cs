using CoolQuest.DbContext.Models;

namespace CoolQuest.backend.DTO
{
    public class QuestionDTO
    {
        public Question question { get; set; }  
       
        public IEnumerable<AnswerFalse> answerFalses { get; set; }
    }
}
