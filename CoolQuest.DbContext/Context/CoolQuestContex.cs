using CoolQuest.DbContext.Models;
using Microsoft.EntityFrameworkCore;

namespace CoolQuest.DbContext.Context
{
    public partial class CoolQuestContex : Microsoft.EntityFrameworkCore.DbContext
    {
        public CoolQuestContex()
        {
            Database.EnsureCreated();
        }

        public CoolQuestContex(DbContextOptions<CoolQuestContex> options)
            : base(options)
        {
        }

        public virtual DbSet<AnswerFalse> AnswerFalses { get; set; } = null!;
        public virtual DbSet<Completed> Completeds { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Models.Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerFalse>(entity =>
            {
                entity.ToTable("AnswerFalse");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AnswerFalses)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswerFalse_Questions");
            });

            modelBuilder.Entity<Completed>(entity =>
            {
                entity.ToTable("Completed");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Completeds)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Completed_Questions");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Completeds)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Completed_Rooms");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Completeds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Completed_Users");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Questions_Rooms");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Type");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Models.Type>(entity =>
            {
                entity.ToTable("Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

