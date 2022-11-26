using CoolQuest.DbContext.Models;

namespace CoolQuest.backend.DTO
{
    public class QuestionDTO
    {
        public string TitleQuestion { get; set; }
        public string Type { get; set; }
        public string Answer { get; set; }

        public IEnumerable<string> AnswerFalses { get; set; }
    }
}
