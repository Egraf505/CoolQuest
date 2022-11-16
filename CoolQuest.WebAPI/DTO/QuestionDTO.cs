using CoolQuest.DbContext.Models;

namespace CoolQuest.backend.DTO
{
    public class QuestionDTO
    {
        public Question question { get; set; }  
        public string Title { get { return question.Title; } set { Title = value; } }
        public IEnumerable<AnswerFalse> answerFalses { get; set; }
    }
}
