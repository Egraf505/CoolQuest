using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolQuest.DbContext.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public string Answer { get; set; }

        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
