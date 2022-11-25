using System;
using System.Collections.Generic;

namespace CoolQuest.DbContext.Models
{
    public partial class Type
    {
        public Type()
        {
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Question> Questions { get; set; }
    }
}
