using System;
using System.Collections.Generic;

namespace ScafoldBD
{
    public partial class Type
    {
        public Type()
        {
            AnswerFalses = new HashSet<AnswerFalse>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<AnswerFalse> AnswerFalses { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
