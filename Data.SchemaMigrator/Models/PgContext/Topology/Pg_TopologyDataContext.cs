using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.SchemaMigrator.Models.PgContext.Topology
{
    public partial class Pg_TopologyDataContext : DbContext
    {
        public Pg_TopologyDataContext()
        {
        }

        public Pg_TopologyDataContext(DbContextOptions<Pg_TopologyDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Layer> Layer { get; set; }
        public virtual DbSet<Topology> Topology { get; set; }

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

            modelBuilder.Entity<Layer>(entity =>
            {
                entity.HasKey(e => new { e.TopologyId, e.LayerId })
                    .HasName("layer_pkey");

                entity.ToTable("layer", "topology");

                entity.HasIndex(e => new { e.SchemaName, e.TableName, e.FeatureColumn })
                    .HasName("layer_schema_name_table_name_feature_column_key")
                    .IsUnique();

                entity.Property(e => e.TopologyId).HasColumnName("topology_id");

                entity.Property(e => e.LayerId).HasColumnName("layer_id");

                entity.Property(e => e.ChildId).HasColumnName("child_id");

                entity.Property(e => e.FeatureColumn)
                    .IsRequired()
                    .HasColumnName("feature_column")
                    .HasColumnType("character varying");

                entity.Property(e => e.FeatureType).HasColumnName("feature_type");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.SchemaName)
                    .IsRequired()
                    .HasColumnName("schema_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasColumnName("table_name")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Topology)
                    .WithMany(p => p.Layer)
                    .HasForeignKey(d => d.TopologyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("layer_topology_id_fkey");
            });

            modelBuilder.Entity<Topology>(entity =>
            {
                entity.ToTable("topology", "topology");

                entity.HasIndex(e => e.Name)
                    .HasName("topology_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topology_id_seq'::regclass)");

                entity.Property(e => e.Hasz).HasColumnName("hasz");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.Srid).HasColumnName("srid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
