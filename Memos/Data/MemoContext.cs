using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Memos.Models;

namespace Memos.Data
{
    public partial class MemoContext : DbContext
    {
        public MemoContext()
        {
        }

        public MemoContext(DbContextOptions<MemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Creator> Creators { get; set; }
        public virtual DbSet<Memo> Memos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KiosekDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Creator>(entity =>
            {
                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Memo>(entity =>
            {
                entity.Property(e => e.MemoId).HasColumnName("MemoID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.MemoBody)
                    .HasMaxLength(280)
                    .IsUnicode(false);

                entity.Property(e => e.MemoHeader)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Memos)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK__Memos__CreatorID__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
