using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolQuest.DbContext.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }       
        public string Password { get; set; }
    }
}
