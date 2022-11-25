using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ScafoldBD
{
    public partial class coolquestdbContext : DbContext
    {
        public coolquestdbContext()
        {
        }

        public coolquestdbContext(DbContextOptions<coolquestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnswerFalse> AnswerFalses { get; set; } = null!;
        public virtual DbSet<Completed> Completeds { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-P6BFK3M\\SQLEXPRESS;Database=coolquestdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerFalse>(entity =>
            {
                entity.ToTable("AnswerFalse");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.AnswerFalses)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswerFalse_Type");
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
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoomId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
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

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
