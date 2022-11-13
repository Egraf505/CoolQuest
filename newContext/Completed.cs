using System;
using System.Collections.Generic;

namespace newContext
{
    public partial class Completed
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
