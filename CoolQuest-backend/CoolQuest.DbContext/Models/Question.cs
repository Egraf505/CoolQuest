using System;
using System.Collections.Generic;

namespace CoolQuest.DbContext.Models
{
    public partial class Question
    {
        public Question()
        {
            AnswerFalses = new HashSet<AnswerFalse>();
            Completeds = new HashSet<Completed>();
        }

        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string? Video { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; } = null!;
        public string Answer { get; set; } = null!;

        public virtual Room? Room { get; set; }
        public virtual Type Type { get; set; } = null!;
        public virtual ICollection<AnswerFalse> AnswerFalses { get; set; }
        public virtual ICollection<Completed> Completeds { get; set; }
    }
}
