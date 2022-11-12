using System;
using System.Collections.Generic;

namespace ScafoldBD
{
    public partial class AnswerFalse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int TypeId { get; set; }

        public virtual Type Type { get; set; } = null!;
    }
}
