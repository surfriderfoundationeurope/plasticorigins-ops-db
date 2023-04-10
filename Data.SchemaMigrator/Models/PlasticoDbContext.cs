using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Data.SchemaMigrator.Models
{
    public partial class PlasticoDbContext : DbContext
    {
        public PlasticoDbContext()
        {
        }

        public PlasticoDbContext(DbContextOptions<PlasticoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basin> Basin { get; set; }
        public virtual DbSet<Campaign_Bi> Campaign_Bi { get; set; }
        public virtual DbSet<Campaign_Bi_Temp> Campaign_Bi_Temp { get; set; }
        public virtual DbSet<Campaign_Campaign> Campaign_Campaign { get; set; }
        public virtual DbSet<CampaignRiver> CampaignRiver { get; set; }
        public virtual DbSet<CampaignRiver_Bi_Temp> CampaignRiver_Bi_Temp { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<LimitsLandSea> LimitsLandSea { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Bi_Log> Bi_Logs { get; set; }
        public virtual DbSet<Bi_Log> Etl_Logs { get; set; }
        public virtual DbSet<AiModel> AiModel { get; set; }
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<Pipelines> Pipelines { get; set; }
        public virtual DbSet<River_Bi> River_Bi { get; set; }
        public virtual DbSet<River_Bi_Temp> River_Bi_Temp { get; set; }
        public virtual DbSet<River_Referential> River_Referential { get; set; }
         public virtual DbSet<Segment_Bi> Segment_Bi { get; set; }
        public virtual DbSet<Segment_Bi_Temp> Segment_Bi_Temp { get; set; }
        public virtual DbSet<Segment_Referential> Segment_Campaign { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Test2> Test2 { get; set; }
        public virtual DbSet<TrajectoryPoint_Bi> TrajectoryPoint_Bi { get; set; }
         public virtual DbSet<TrajectoryPoint_Bi_Temp> TrajectoryPoint_Bi_Temp { get; set; }
        public virtual DbSet<TrajectoryPoint_Campaign> TrajectoryPoint_Campaign { get; set; }
        public virtual DbSet<TrajectoryPointRiver> TrajectoryPointRiver { get; set; }
        public virtual DbSet<TrajectoryPointRiver_Bi_Temp> TrajectoryPointRiver_Bi_Temp { get; set; }
        public virtual DbSet<Trash_Bi> Trash_Bi { get; set; }
        public virtual DbSet<Trash_Bi_Temp> Trash_Bi_Temp { get; set; }
        public virtual DbSet<Trash_Campaign> Trash_Campaign { get; set; }
        public virtual DbSet<TrashRiver> TrashRiver { get; set; }
        public virtual DbSet<TrashRiver_Bi_Temp> TrashRiver_Bi_Temp { get; set; }
        public virtual DbSet<TrashType> TrashType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ImagesForLabelling> ImagesForLabelling { get; set; }
        public virtual DbSet<BoundingBoxes> BoundingBoxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.local.json").Build();
            var cs = configuration.GetConnectionString("PostgreSql");
            optionsBuilder.UseNpgsql(cs, x => x.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pgcrypto")
                // .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_topology")
                .HasPostgresExtension("uuid-ossp");
            
            
            modelBuilder.Entity<Basin>(entity =>
            {
                entity.ToTable("basin", "referential");

                entity.HasIndex(e => e.AreaSquareKm);

                entity.HasIndex(e => e.TheGeomBB)
                    .HasMethod("gist");

                entity.Property(e => e.BasinId).HasColumnName("basin_id");

                entity.Property(e => e.FecCount).HasColumnName("fec_count");

                entity.Property(e => e.BasinName).HasColumnName("basin_name");

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.FeatureCollection)
                    .HasColumnName("feature_collection")
                    .HasColumnType("jsonb");

                entity.Property(e => e.AreaSquareKm).HasColumnName("area_square_km");

                entity.Property(e => e.TheGeomBB).HasColumnName("the_geom_bb");
            });

            modelBuilder.Entity<Campaign_Bi>(entity =>
            {
                entity.ToTable("campaign", "bi");

                entity.HasIndex(e => e.EndPoint)
                    .HasName("campaign_end_point")
                    .HasMethod("gist");

                entity.HasIndex(e => e.StartPoint)
                    .HasName("campaign_start_point")
                    .HasMethod("gist");

                entity.HasIndex(e => e.Id)
                    .HasName("campaign_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvgSpeed).HasColumnName("avg_speed");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.EndPoint).HasColumnName("end_point");

                entity.Property(e => e.IdRefModelFk).HasColumnName("id_ref_model_fk");

                entity.Property(e => e.IdRefUserFk).HasColumnName("id_ref_user_fk");

                entity.Property(e => e.Isaidriven).HasColumnName("isaidriven");

                entity.Property(e => e.Locomotion).HasColumnName("locomotion");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.Riverside).HasColumnName("riverside");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.StartPoint).HasColumnName("start_point");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.TrashCount).HasColumnName("trash_count");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

            });

            modelBuilder.Entity<Campaign_Bi_Temp>(entity =>
            {
                entity.ToTable("campaign", "bi_temp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AvgSpeed).HasColumnName("avg_speed");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.EndPoint).HasColumnName("end_point");

                entity.Property(e => e.EndPointDistanceSea).HasColumnName("end_point_distance_sea");

                entity.Property(e => e.IdRefModelFk).HasColumnName("id_ref_model_fk");

                entity.Property(e => e.IdRefUserFk).HasColumnName("id_ref_user_fk");

                entity.Property(e => e.Isaidriven).HasColumnName("isaidriven");

                entity.Property(e => e.Locomotion).HasColumnName("locomotion");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.Riverside).HasColumnName("riverside");

                entity.Property(e => e.StartDate).HasColumnName("start_date");

                entity.Property(e => e.StartPoint).HasColumnName("start_point");

                entity.Property(e => e.StartPointDistanceSea).HasColumnName("start_point_distance_sea");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.TrashCount).HasColumnName("trash_count");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

            });

            modelBuilder.Entity<Campaign_Campaign>(entity =>
            {
                entity.ToTable("campaign", "campaign");

                entity.HasIndex(e => e.Id)
                    .HasName("campaign_id");

                entity.HasIndex(e => e.IdRefModelFk);

                entity.HasIndex(e => e.IdRefUserFk);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.HasBeenComputed).HasColumnName("has_been_computed");

                entity.Property(e => e.IdRefModelFk).HasColumnName("id_ref_model_fk");

                entity.Property(e => e.IdRefUserFk).HasColumnName("id_ref_user_fk");

                entity.Property(e => e.Isaidriven).HasColumnName("isaidriven");

                entity.Property(e => e.Locomotion)
                    .IsRequired()
                    .HasColumnName("locomotion");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.Riverside).HasColumnName("riverside");

                entity.HasOne(d => d.IdRefModelFkNavigation)
                    .WithMany(p => p.Campaigns_Campaign)
                    .HasForeignKey(d => d.IdRefModelFk)
                    .HasConstraintName("campaign_id_ref_model_fk_fkey");

                entity.HasOne(d => d.IdRefUserFkNavigation)
                    .WithMany(p => p.Campaigns_Campaign)
                    .HasForeignKey(d => d.IdRefUserFk)
                    .HasConstraintName("campaign_id_ref_user_fk_fkey");
            });

            modelBuilder.Entity<CampaignRiver>(entity =>
            {
                entity.ToTable("campaign_river", "bi");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.TheGeom)
                    .HasName("campaign_river_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Distance)
                    .HasColumnName("distance")
                    .HasColumnType("numeric");
                
                entity.Property(e => e.TrashCount).HasColumnName("trash_count");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.FeatureCollection)
                    .HasColumnName("feature_collection")
                    .HasColumnType("jsonb");
                
                entity.Property(e => e.Disabled).HasColumnName("disabled");
            });

            modelBuilder.Entity<CampaignRiver_Bi_Temp>(entity =>
            {
                entity.ToTable("campaign_river", "bi_temp");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Distance)
                    .HasColumnName("distance")
                    .HasColumnType("numeric");
                
                entity.Property(e => e.TrashCount).HasColumnName("trash_count");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");
            });

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
                
                entity.Property(e => e.FeatureCollection)
                    .HasColumnName("feature_collection")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department", "referential");

                entity.HasIndex(e => e.Code)
                    .HasName("referential_department_code");

                entity.HasIndex(e => e.IdRefStateFk);

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

                entity.HasIndex(e => e.IdRefCountryFk);

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

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("media", "campaign");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.IdRefTrajectoryPointsFk);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BlobUrl)
                    .IsRequired()
                    .HasColumnName("blob_url");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefTrajectoryPointsFk).HasColumnName("id_ref_trajectory_points_fk");

                entity.Property(e => e.Isdeleted)
                    .IsRequired()
                    .HasColumnName("isdeleted")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.IdRefCampaignFkNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.IdRefCampaignFk)
                    .HasConstraintName("image_id_ref_campaign_fk_fkey");

                entity.HasOne(d => d.IdRefTrajectoryPointsFkNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.IdRefTrajectoryPointsFk)
                    .HasConstraintName("image_id_ref_trajectory_points_fk_fkey");
            });

           modelBuilder.Entity<Bi_Log>(entity =>
            {
                entity.ToTable("bi", "logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignId)
                    .HasColumnName("campaign_id");  

                entity.Property(e => e.ElapsedTime).HasColumnName("elapsed_time");

                entity.Property(e => e.FinishedOn)
                    .HasColumnName("finished_on")
                    .HasColumnType("date");

                entity.Property(e => e.InitiatedOn)
                    .HasColumnName("initiated_on")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValue("HARD_FAIL")
                    .HasColumnName("status");

                entity.Property(e => e.Reason).HasColumnName("reason");
                
                entity.Property(e => e.ScriptVersion).HasColumnName("script_version");

                entity.Property(e => e.FailedStep).HasColumnName("failed_step");

                entity.HasIndex(e => e.CampaignId).HasName("IX_bi_campaign_id");
            });

            modelBuilder.Entity<Etl_Log>(entity =>
            {
                entity.ToTable("etl", "logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignId)
                    .HasColumnName("campaign_id");
                
                entity.Property(e => e.MediaId)
                    .HasColumnName("media_id");

                entity.Property(e => e.MediaName)
                    .HasColumnName("media_name");

                entity.HasOne(d => d.EtlLogs_Campaign_CampaignFKNavigation)
                    .WithMany(p => p.Etl_Logs)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("fk_campaign_id");

                entity.Property(e => e.ElapsedTime).HasColumnName("elapsed_time");

                entity.Property(e => e.FinishedOn)
                    .HasColumnName("finished_on")
                    .HasColumnType("date");

                entity.Property(e => e.InitiatedOn)
                    .HasColumnName("initiated_on")
                    .HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValue("HARD_FAIL")
                    .HasColumnName("status");
                
                entity.Property(e => e.MediaName)
                    .IsRequired()
                    .HasColumnName("media_name");

                entity.Property(e => e.Reason).HasColumnName("reason");
                
                entity.Property(e => e.ScriptVersion).HasColumnName("script_version");

                entity.Property(e => e.Container).HasColumnName("container");

                entity.HasIndex(e => e.MediaId).HasName("IX_etl_media_id");
            });

            modelBuilder.Entity<AiModel>(entity =>
            {
                entity.ToTable("model", "campaign");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.ToTable("municipality", "referential");

                entity.HasIndex(e => e.Code)
                    .HasName("municipality_code");

                entity.HasIndex(e => e.IdRefDepartmentFk);

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

            modelBuilder.Entity<Pipelines>(entity =>
            {
                entity.ToTable("pipelines", "bi_temp");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CampaignId).HasColumnName("campaign_id");

                entity.Property(e => e.CampaignHasBeenComputed)
                    .HasColumnName("campaign_has_been_computed");

                entity.Property(e => e.RiverHasBeenComputed)
                    .HasColumnName("river_has_been_computed");
            });

            modelBuilder.Entity<River_Referential>(entity =>
            {
                entity.ToTable("river", "referential");

                entity.HasIndex(e => e.Id).HasName("river_id");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("river_the_geom")
                    .HasMethod("gist");

                entity.HasIndex(e => e.Importance)
                    .HasName("river_importance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");
                
                entity.Property(e => e.Importance).HasColumnName("importance");
            });

            modelBuilder.Entity<River_Bi>(entity =>
            {
                entity.ToTable("river", "bi");

                entity.HasIndex(e => e.Id)
                    .HasName("river_id");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("river_the_geom")
                    .HasMethod("gist");

                entity.HasIndex(e => e.Importance)
                    .HasName("river_bi_importance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.CountTrash).HasColumnName("count_trash");

                entity.Property(e => e.DistanceMonitored).HasColumnName("distance_monitored");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeomMonitored).HasColumnName("the_geom_monitored");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");
                
                entity.Property(e => e.NbCampaign).HasColumnName("nb_campaign");

                 entity.Property(e => e.TheGeom)
                    .HasColumnName("the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.FeatureCollection)
                    .HasColumnName("feature_collection")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<River_Bi_Temp>(entity =>
            {
                entity.ToTable("river", "bi_temp");

                
                entity.HasIndex(e => e.Id)
                    .HasName("bi_temp_river_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.CountTrash).HasColumnName("count_trash");

                entity.Property(e => e.DistanceMonitored).HasColumnName("distance_monitored");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeomMonitored).HasColumnName("the_geom_monitored");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");

                entity.Property(e => e.NbCampaign).HasColumnName("nb_campaign");

                 entity.Property(e => e.TheGeom)
                    .HasColumnName("the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

            });

            modelBuilder.Entity<Segment_Referential>(entity =>
            {
                entity.ToTable("segment", "referential");

                entity.HasIndex(e => e.IdRefCountryFk);
                entity.HasIndex(e => e.IdRefRiverFk);

                entity.HasIndex(e => e.Id).HasName("segment_id");

                entity.HasIndex(e => e.Importance)
                    .HasName("segment_importance");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("segment_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.Bras).HasColumnName("bras");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefCountryFk).HasColumnName("id_ref_country_fk");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.StrahlerRank).HasColumnName("strahler_rank");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.TheGeom)
                    .IsRequired()
                    .HasColumnName("the_geom");
                

                entity.HasOne(d => d.IdRefCountryFkNavigation)
                    .WithMany(p => p.Segment)
                    .HasForeignKey(d => d.IdRefCountryFk)
                    .HasConstraintName("segment_id_ref_country_fk_fkey");

                entity.HasOne(d => d.IdRefRiverFkNavigation)
                    .WithMany(p => p.Segment)
                    .HasForeignKey(d => d.IdRefRiverFk)
                    .HasConstraintName("segment_id_ref_river_fk_fkey");
            });

            modelBuilder.Entity<Segment_Bi_Temp>(entity =>
            {
                entity.ToTable("segment", "bi_temp");
                
                entity.HasIndex(e => e.Id)
                    .HasName("bi_temp_segment_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.CountTrash).HasColumnName("count_trash");

                entity.Property(e => e.DistanceMonitored).HasColumnName("distance_monitored");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");

                entity.Property(e => e.NbCampaign).HasColumnName("nb_campaign");

                entity.Property(e => e.CountTrashRiver).HasColumnName("count_trash_river");

                entity.Property(e => e.DistanceMonitoredRiver).HasColumnName("distance_monitored_river");

                entity.Property(e => e.TrashPerKmRiver)
                    .HasColumnName("trash_per_km_river")
                    .HasColumnType("numeric");

                entity.Property(e => e.NbCampaignRiver).HasColumnName("nb_campaign_river");

                entity.Property(e => e.TheGeomMonitored).HasColumnName("the_geom_monitored");

                 entity.Property(e => e.TheGeom)
                    .HasColumnName("the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

            });

            modelBuilder.Entity<Segment_Bi>(entity =>
            {
                entity.ToTable("segment", "bi");
                
                entity.HasIndex(e => e.Id)
                    .HasName("bi_segment_id");
                
                entity.HasIndex(e => e.Importance)
                    .HasName("bi_segment_importance");
                
                entity.HasIndex(e => e.TheGeom)
                .HasName("segment_the_geom")
                .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.CountTrash).HasColumnName("count_trash");

                entity.Property(e => e.DistanceMonitored).HasColumnName("distance_monitored");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");
                

                entity.Property(e => e.NbCampaign).HasColumnName("nb_campaign");

                entity.Property(e => e.CountTrashRiver).HasColumnName("count_trash_river");

                entity.Property(e => e.DistanceMonitoredRiver).HasColumnName("distance_monitored_river");

                entity.Property(e => e.TrashPerKmRiver)
                    .HasColumnName("trash_per_km_river")
                    .HasColumnType("numeric");

                entity.Property(e => e.NbCampaignRiver).HasColumnName("nb_campaign_river");

                entity.Property(e => e.TheGeom)
                    .HasColumnName("the_geom");

                entity.Property(e => e.TheGeomMonitored).HasColumnName("the_geom_monitored");

                entity.Property(e => e.Createdon).HasColumnName("createdon");
                
                entity.Property(e => e.FeatureCollection)
                    .HasColumnName("feature_collection")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state", "referential");

                entity.HasIndex(e => e.Code)
                    .HasName("state_code");

                entity.HasIndex(e => e.IdRefCountryFk);

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
            
            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test");

                entity.Property(e => e.B).HasColumnName("b");
            });

            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test2");

                entity.Property(e => e.B).HasColumnName("b");
            });

            modelBuilder.Entity<TrajectoryPoint_Campaign>(entity =>
            {
                entity.ToTable("trajectory_point", "campaign");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("trajectory_point_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.HasOne(d => d.IdRefCampaignFkNavigation)
                    .WithMany(p => p.TrajectoryPoints_Campaign)
                    .HasForeignKey(d => d.IdRefCampaignFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trajectory_point_id_ref_campaign_fk_fkey");
            });

            modelBuilder.Entity<TrajectoryPoint_Bi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("trajectory_point", "bi");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.TimeDiff).HasColumnName("time_diff");
            });

            modelBuilder.Entity<TrajectoryPoint_Bi_Temp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("trajectory_point", "bi_temp");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.Id);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.TimeDiff).HasColumnName("time_diff");
            });

            modelBuilder.Entity<TrajectoryPointRiver>(entity =>
            {
                entity.ToTable("trajectory_point_river", "bi");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefSegmentFk).HasColumnName("id_ref_segment_fk");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrajectoryPointFk).HasColumnName("id_ref_trajectory_point_fk");

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<TrajectoryPointRiver_Bi_Temp>(entity =>
            {
                entity.ToTable("trajectory_point_river", "bi_temp");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.IdRefRiverFk);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefSegmentFk).HasColumnName("id_ref_segment_fk");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrajectoryPointFk).HasColumnName("id_ref_trajectory_point_fk");

                entity.Property(e => e.Time).HasColumnName("time");
            });

            modelBuilder.Entity<Trash_Bi>(entity =>
            {
                entity.ToTable("trash", "bi");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.Id);

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

                entity.Property(e => e.MunicipalityCode).HasColumnName("municipality_code");
                entity.Property(e => e.MunicipalityName).HasColumnName("municipality_name");
                entity.Property(e => e.DepartmentCode).HasColumnName("department_code");
                entity.Property(e => e.DepartmentName).HasColumnName("department_name");
                entity.Property(e => e.StateCode).HasColumnName("state_code");
                entity.Property(e => e.StateName).HasColumnName("state_name");
                entity.Property(e => e.CountryCode).HasColumnName("country_code");
                entity.Property(e => e.CountryName).HasColumnName("country_name");

                entity.HasIndex(e => e.TheGeom).HasName("bi_trash_the_geom");
            });

            modelBuilder.Entity<Trash_Bi_Temp>(entity =>
            {
                entity.ToTable("trash", "bi_temp");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.Id);

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefImageFk).HasColumnName("id_ref_media_fk");

                entity.Property(e => e.IdRefModelFk).HasColumnName("id_ref_model_fk");

                entity.Property(e => e.IdRefTrashTypeFk).HasColumnName("id_ref_trash_type_fk");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.MunicipalityCode).HasColumnName("municipality_code");
                entity.Property(e => e.MunicipalityName).HasColumnName("municipality_name");
                entity.Property(e => e.DepartmentCode).HasColumnName("department_code");
                entity.Property(e => e.DepartmentName).HasColumnName("department_name");
                entity.Property(e => e.StateCode).HasColumnName("state_code");
                entity.Property(e => e.StateName).HasColumnName("state_name");
                entity.Property(e => e.CountryCode).HasColumnName("country_code");
                entity.Property(e => e.CountryName).HasColumnName("country_name");

                entity.HasIndex(e => e.TheGeom).HasName("bi_trash_the_geom");
            });

            modelBuilder.Entity<Trash_Campaign>(entity =>
            {
                entity.ToTable("trash", "campaign");

                entity.HasIndex(e => e.IdRefImageFk);

                entity.HasIndex(e => e.IdRefModelFk);

                entity.HasIndex(e => e.IdRefTrashTypeFk);

                entity.HasIndex(e => e.TheGeom)
                    .HasName("trash_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");



                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.Frame2Box).HasColumnName("frame_2_box").HasColumnType("jsonb");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefImageFk).HasColumnName("id_ref_image_fk");

                entity.Property(e => e.IdRefModelFk).HasColumnName("id_ref_model_fk");

                entity.Property(e => e.IdRefTrashTypeFk).HasColumnName("id_ref_trash_type_fk");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.IdRefCampaignFkNavigation)
                    .WithMany(p => p.Trash1)
                    .HasForeignKey(d => d.IdRefCampaignFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trash_id_ref_campaign_fk_fkey");

                entity.HasOne(d => d.IdRefImageFkNavigation)
                    .WithMany(p => p.Trash1)
                    .HasForeignKey(d => d.IdRefImageFk)
                    .HasConstraintName("trash_id_ref_image_fk_fkey");

                entity.HasOne(d => d.IdRefModelFkNavigation)
                    .WithMany(p => p.Trash1)
                    .HasForeignKey(d => d.IdRefModelFk)
                    .HasConstraintName("trash_id_ref_model_fk_fkey");
            });

            modelBuilder.Entity<TrashRiver>(entity =>
            {
                entity.ToTable("trash_river", "bi");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.IdRefTrashFk);

                entity.HasIndex(e => e.Id);

                entity.HasIndex(e => e.TheGeom)
                    .HasName("trash_river_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefSegmentFk).HasColumnName("id_ref_segment_fk");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrashFk).HasColumnName("id_ref_trash_fk");
                
                entity.Property(e => e.FeatureCollection)
                    .HasColumnName("feature_collection")
                    .HasColumnType("jsonb");
            });
                
            modelBuilder.Entity<TrashRiver_Bi_Temp>(entity =>
            {
                entity.ToTable("trash_river", "bi_temp");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.IdRefRiverFk);

                entity.HasIndex(e => e.IdRefSegmentFk);

                entity.HasIndex(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.IdRefSegmentFk).HasColumnName("id_ref_segment_fk");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrashFk).HasColumnName("id_ref_trash_fk");

            });

            modelBuilder.Entity<TrashType>(entity =>
            {
                entity.ToTable("trash_type", "campaign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "campaign");

                entity.HasIndex(e => e.Firstname)
                    .HasName("user_firstname");

                entity.HasIndex(e => e.Lastname)
                    .HasName("user_lastname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Emailconfirmed).HasColumnName("emailconfirmed");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");

                entity.Property(e => e.Lastname).HasColumnName("lastname");

                entity.Property(e => e.LastLoggedOn).HasColumnName("lastloggedon");

                entity.Property(e => e.Nickname).HasColumnName("nickname");

                entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");

                entity.Property(e => e.Yearofbirth)
                    .HasColumnName("yearofbirth")
                    .HasColumnType("date");

                entity.Property(e => e.CGUValidatedDate).HasColumnName("cguvalidateddate");
            });

            modelBuilder.Entity<ImagesForLabelling>(entity =>
            {
                entity.ToTable("images_for_labelling", "label");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.IdCreatorFk).HasColumnName("id_creator_fk");

                entity.Property(e => e.CreatedOn).HasColumnName("createdon");

                entity.Property(e => e.Filename).HasColumnName("filename");

                entity.Property(e => e.View).HasColumnName("view");

                entity.Property(e => e.ImageQuality).HasColumnName("image_quality");

                entity.Property(e => e.Context).HasColumnName("context");

                entity.Property(e => e.ContainerUrl).HasColumnName("container_url");

                entity.Property(e => e.BlobName).HasColumnName("blob_name");

                // Index
                entity.HasIndex(e => e.IdCreatorFk).HasName("IX_images_for_labelling_IdCreatorFk");
            });

            modelBuilder.Entity<BoundingBoxes>(entity =>
           {
               entity.ToTable("bounding_boxes", "label");

               entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasDefaultValueSql("uuid_generate_v4()");
                
               entity.Property(e => e.IdCreatorFk).HasColumnName("id_creator_fk");

               entity.Property(e => e.IdRefTrashTypeFk).HasColumnName("id_ref_trash_type_fk");
               
               entity.Property(e => e.IdRefImagesForLabelling).HasColumnName("id_ref_images_for_labelling");
               
               entity.Property(e => e.CreatedOn).HasColumnName("createdon");

               entity.Property(e => e.LocationX).HasColumnName("location_x");

               entity.Property(e => e.LocationY).HasColumnName("location_y");

               entity.Property(e => e.Width).HasColumnName("width");

               entity.Property(e => e.Height).HasColumnName("height");


                // Index
               entity.HasIndex(e => e.IdCreatorFk).HasName("IX_bounding_boxes_IdCreatorFk");
               entity.HasIndex(e => e.IdRefTrashTypeFk).HasName("IX_bounding_boxes_IdRefTrashTypeFk");

               entity.HasOne(d => d.ImageForLabelling)
                   .WithMany(p => p.ImagesForLabellingBoundingBoxesNavigation)
                   .HasForeignKey(d => d.IdRefImagesForLabelling)
                   .HasConstraintName("id_ref_images_for_labelling_fk");
           });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
