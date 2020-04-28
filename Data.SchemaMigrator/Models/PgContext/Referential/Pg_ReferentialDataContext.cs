using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.SchemaMigrator.Models.PgContext.Referential
{
    public partial class Pg_ReferentialDataContext : DbContext
    {
        public Pg_ReferentialDataContext()
        {
        }

        public Pg_ReferentialDataContext(DbContextOptions<Pg_ReferentialDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<LimitsLandSea> LimitsLandSea { get; set; }
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<River> River { get; set; }
        public virtual DbSet<State> State { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=surfrider-geodata.postgres.database.azure.com;Database=postgres;Port=5432;User Id=SurfriderAdmin@surfrider-geodata;Password=PlastiqueEnFolie!;Ssl Mode=Require;", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_topology")
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country", "referential");

                entity.HasIndex(e => e.Code)
                    .HasName("country_code");

                entity.HasIndex(e => e.Name)
                    .HasName("country_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.TheGeom)
                    .HasName("country_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department", "referential");

                entity.HasIndex(e => e.Code)
                    .HasName("referential_department_code");

                entity.HasIndex(e => e.Name)
                    .HasName("department_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.TheGeom)
                    .HasName("referential_department_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefStateFk).HasColumnName("id_ref_state_fk");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");

                entity.HasOne(d => d.IdRefStateFkNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.IdRefStateFk)
                    .HasConstraintName("department_id_ref_state_fk_fkey");
            });

            modelBuilder.Entity<LimitsLandSea>(entity =>
            {
                entity.ToTable("limits_land_sea", "referential");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("limits_land_sea_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefCountryFk).HasColumnName("id_ref_country_fk");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");

                entity.HasOne(d => d.IdRefCountryFkNavigation)
                    .WithMany(p => p.LimitsLandSea)
                    .HasForeignKey(d => d.IdRefCountryFk)
                    .HasConstraintName("limits_land_sea_id_ref_country_fk_fkey");
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.ToTable("municipality", "referential");

                entity.HasIndex(e => e.Code)
                    .HasName("municipality_code");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("municipality_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefDepartmentFk).HasColumnName("id_ref_department_fk");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");

                entity.HasOne(d => d.IdRefDepartmentFkNavigation)
                    .WithMany(p => p.Municipality)
                    .HasForeignKey(d => d.IdRefDepartmentFk)
                    .HasConstraintName("municipality_id_ref_department_fk_fkey");
            });

            modelBuilder.Entity<River>(entity =>
            {
                entity.ToTable("river", "referential");

                entity.HasIndex(e => e.Importance)
                    .HasName("river_importance");

                entity.HasIndex(e => e.Name)
                    .HasName("river_name");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("river_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bras).HasColumnName("bras");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefCountryFk).HasColumnName("id_ref_country_fk");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");

                entity.HasOne(d => d.IdRefCountryFkNavigation)
                    .WithMany(p => p.River)
                    .HasForeignKey(d => d.IdRefCountryFk)
                    .HasConstraintName("river_id_ref_country_fk_fkey");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state", "referential");

                entity.HasIndex(e => e.Code)
                    .HasName("state_code");

                entity.HasIndex(e => e.Name)
                    .HasName("state_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.TheGeom)
                    .HasName("state_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefCountryFk).HasColumnName("id_ref_country_fk");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");

                entity.HasOne(d => d.IdRefCountryFkNavigation)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.IdRefCountryFk)
                    .HasConstraintName("state_id_ref_country_fk_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
