using CoolQuest.DbContext.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolQuest.DbContext.Context
{
    public class CoolQuestContex : Microsoft.EntityFrameworkCore.DbContext
    {
        // Таблицы
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Room> Rooms { get; set; }

        // Конструкток с созданием базы 
        public CoolQuestContex(DbContextOptions<CoolQuestContex> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
