using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:dev-trashroulette.database.windows.net,1433;Initial Catalog=dev-trashroulette;Persist Security Info=False;User ID=SurfriderAdmin;Password=PlastiqueEnFolie!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
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
