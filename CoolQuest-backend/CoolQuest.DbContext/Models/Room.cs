using System;
using System.Collections.Generic;

namespace CoolQuest.DbContext.Models
{
    public partial class Room
    {
        public Room()
        {
            Completeds = new HashSet<Completed>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Completed> Completeds { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
