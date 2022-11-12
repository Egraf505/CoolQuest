using System;
using System.Collections.Generic;

namespace ScafoldBD
{
    public partial class User
    {
        public User()
        {
            Completeds = new HashSet<Completed>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Completed> Completeds { get; set; }
    }
}
