using System;
using System.Collections.Generic;

namespace CoolQuest.DbContext.Models
{
    public partial class AnswerFalse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; } = null!;
    }
}
