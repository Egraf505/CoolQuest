
using System.ComponentModel.DataAnnotations.Schema;

namespace CoolQuest.DbContext.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
