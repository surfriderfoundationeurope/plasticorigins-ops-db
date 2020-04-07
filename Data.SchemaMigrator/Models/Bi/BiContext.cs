using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Data.SchemaMigrator.Models.Bi
{
    public partial class BiContext : DbContext
    {
        public BiContext()
        {
        }

        public BiContext(DbContextOptions<BiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<River> River { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var biContextCs = Program.GetConnectionString();
            optionsBuilder.UseSqlServer(biContextCs);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign", "bi");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("Logs", "bi");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<River>(entity =>
            {
                entity.ToTable("River", "bi");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MeanDensityOfLitter).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "bi");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
