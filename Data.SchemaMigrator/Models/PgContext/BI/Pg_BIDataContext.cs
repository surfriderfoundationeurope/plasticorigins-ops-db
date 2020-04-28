using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.SchemaMigrator.Models.PgContext.BI
{
    public partial class Pg_BIDataContext : DbContext
    {
        public Pg_BIDataContext()
        {
        }

        public Pg_BIDataContext(DbContextOptions<Pg_BIDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignRiver> CampaignRiver { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<River> River { get; set; }
        public virtual DbSet<TrajectoryPointRiver> TrajectoryPointRiver { get; set; }
        public virtual DbSet<Trash> Trash { get; set; }
        public virtual DbSet<TrashRiver> TrashRiver { get; set; }

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

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("campaign", "bi");

                entity.HasIndex(e => e.EndPoint)
                    .HasName("campaign_end_point")
                    .HasMethod("gist");

                entity.HasIndex(e => e.IdRefCampaignFk)
                    .HasName("campaign_id_ref_campaign_fk");

                entity.HasIndex(e => e.StartPoint)
                    .HasName("campaign_start_point")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvgSpeed).HasColumnName("avg_speed");

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("date");

                entity.Property(e => e.DistanceStartEnd).HasColumnName("distance_start_end");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.EndPoint).HasColumnName("end_point");

                entity.Property(e => e.EndPointDistanceSea).HasColumnName("end_point_distance_sea");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartPoint).HasColumnName("start_point");

                entity.Property(e => e.StartPointDistanceSea).HasColumnName("start_point_distance_sea");

                entity.Property(e => e.TotalDistance).HasColumnName("total_distance");

                entity.Property(e => e.TrashCount).HasColumnName("trash_count");
            });

            modelBuilder.Entity<CampaignRiver>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("campaign_river", "bi");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.RiverName).HasColumnName("river_name");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("logs", "bi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ElapsedTime).HasColumnName("elapsed_time");

                entity.Property(e => e.FinishedOn)
                    .HasColumnName("finished_on")
                    .HasColumnType("date");

                entity.Property(e => e.InitiatedOn)
                    .HasColumnName("initiated_on")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status");
            });

            modelBuilder.Entity<River>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("river", "bi");

                entity.Property(e => e.DistanceMonitored).HasColumnName("distance_monitored");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Trace).HasColumnName("trace");

                entity.Property(e => e.TrashDetected).HasColumnName("trash_detected");
            });

            modelBuilder.Entity<TrajectoryPointRiver>(entity =>
            {
                entity.ToTable("trajectory_point_river", "bi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClosestPointTheGeom)
                    .IsRequired()
                    .HasColumnName("closest_point_the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.DistanceRiverTrajectoryPoint).HasColumnName("distance_river_trajectory_point");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrajectoryPointFk).HasColumnName("id_ref_trajectory_point_fk");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.ProjectionTrajectoryPointRiverTheGeom)
                    .IsRequired()
                    .HasColumnName("projection_trajectory_point_river_the_geom");

                entity.Property(e => e.RiverName).HasColumnName("river_name");

                entity.Property(e => e.RiverTheGeom)
                    .IsRequired()
                    .HasColumnName("river_the_geom");

                entity.Property(e => e.TrajectoryPointTheGeom)
                    .IsRequired()
                    .HasColumnName("trajectory_point_the_geom");
            });

            modelBuilder.Entity<Trash>(entity =>
            {
                entity.ToTable("trash", "bi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.BrandType).HasColumnName("brand_type");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefImageFk).HasColumnName("id_ref_image_fk");

                entity.Property(e => e.IdRefModelFk).HasColumnName("id_ref_model_fk");

                entity.Property(e => e.IdRefTrashTypeFk).HasColumnName("id_ref_trash_type_fk");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<TrashRiver>(entity =>
            {
                entity.ToTable("trash_river", "bi");

                entity.HasIndex(e => e.ClosestPointTheGeom)
                    .HasName("bi_trash_river_closest_point_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClosestPointTheGeom)
                    .IsRequired()
                    .HasColumnName("closest_point_the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.DistanceRiverTrash).HasColumnName("distance_river_trash");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrashFk).HasColumnName("id_ref_trash_fk");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.ProjectionTrashRiverTheGeom)
                    .IsRequired()
                    .HasColumnName("projection_trash_river_the_geom");

                entity.Property(e => e.RiverName).HasColumnName("river_name");

                entity.Property(e => e.RiverTheGeom)
                    .IsRequired()
                    .HasColumnName("river_the_geom");

                entity.Property(e => e.TrashTheGeom)
                    .IsRequired()
                    .HasColumnName("trash_the_geom");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
