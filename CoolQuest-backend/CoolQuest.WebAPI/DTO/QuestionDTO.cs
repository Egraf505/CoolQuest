using CoolQuest.DbContext.Models;
using CoolQuest.WebAPI.DTO;

namespace CoolQuest.backend.DTO
{
    public class QuestionDTO
    {
        public string TitleQuestion { get; set; }
        public string Type { get; set; }
        public string Answer { get; set; }

        public IEnumerable<AnswerFalseDTO> AnswerFalses { get; set; }
    }
}
