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

        public virtual DbSet<ArrondissementDepartemental> ArrondissementDepartemental { get; set; }
        public virtual DbSet<BassinVersantTopographique> BassinVersantTopographique { get; set; }
        public virtual DbSet<Campaign_Bi> Campaign_Bi { get; set; }
        public virtual DbSet<Campaign_Campaign> Campaign_Campaign { get; set; }
        public virtual DbSet<CampaignRiver> CampaignRiver { get; set; }
        public virtual DbSet<ChefLieu> ChefLieu { get; set; }
        public virtual DbSet<Commune> Commune { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CoursDEau> CoursDEau { get; set; }
        public virtual DbSet<Departement> Departement { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DetailHydrographique> DetailHydrographique { get; set; }
        public virtual DbSet<Epci> Epci { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<LimiteTerreMer> LimiteTerreMer { get; set; }
        public virtual DbSet<LimitsLandSea> LimitsLandSea { get; set; }
        public virtual DbSet<Bi_Log> Bi_Logs { get; set; }
        public virtual DbSet<Bi_Log> Etl_Logs { get; set; }
        public virtual DbSet<AiModel> AiModel { get; set; }
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<NoeudHydrographique> NoeudHydrographique { get; set; }
        public virtual DbSet<PlanDEau> PlanDEau { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<River_Referential> River_Campaign { get; set; }
        public virtual DbSet<River_Bi> River_Bi { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SurfaceHydrographique> SurfaceHydrographique { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Test2> Test2 { get; set; }
        public virtual DbSet<ToponymieHydrographie> ToponymieHydrographie { get; set; }
        public virtual DbSet<Traces> Traces { get; set; }
        public virtual DbSet<TrajectoryPoint_Campaign> TrajectoryPoint_Campaign { get; set; }
        public virtual DbSet<TrajectoryPoint_Bi> TrajectoryPoint_Bi { get; set; }
        public virtual DbSet<TrajectoryPointRiver> TrajectoryPointRiver { get; set; }
        public virtual DbSet<Trash_Bi> Trash_Bi { get; set; }
        public virtual DbSet<Trash_Campaign> Trash_Campaign { get; set; }
        public virtual DbSet<Trash_RawData> Trash_RawData { get; set; }
        public virtual DbSet<TrashRiver> TrashRiver { get; set; }
        public virtual DbSet<TrashType> TrashType { get; set; }
        public virtual DbSet<TronconHydrographique> TronconHydrographique { get; set; }
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
                .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_topology")
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<ArrondissementDepartemental>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("arrondissement_departemental", "raw_data");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InseeArr).HasColumnName("insee_arr");

                entity.Property(e => e.InseeDep).HasColumnName("insee_dep");

                entity.Property(e => e.InseeReg).HasColumnName("insee_reg");
            });

            modelBuilder.Entity<BassinVersantTopographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("bassin_versant_topographique", "raw_data");

                entity.Property(e => e.BFluvial).HasColumnName("b_fluvial");

                entity.Property(e => e.BassHydro).HasColumnName("bass_hydro");

                entity.Property(e => e.CodeBh).HasColumnName("code_bh");

                entity.Property(e => e.CodeCarth).HasColumnName("code_carth");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCEau).HasColumnName("id_c_eau");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.PrecPlani).HasColumnName("prec_plani");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.SrcCoord).HasColumnName("src_coord");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.Property(e => e.Toponyme).HasColumnName("toponyme");
            });

            modelBuilder.Entity<Campaign_Bi>(entity =>
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

                entity.Property(e => e.BlobName).HasColumnName("blob_name");

                entity.Property(e => e.ContainerUrl).HasColumnName("container_url");

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

                entity.Property(e => e.IdRefModelFk).HasColumnName("id_ref_model_fk");

                entity.Property(e => e.IdRefUserFk).HasColumnName("id_ref_user_fk");

                entity.Property(e => e.Isaidriven).HasColumnName("isaidriven");

                entity.Property(e => e.Locomotion).HasColumnName("locomotion");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.Riverside).HasColumnName("riverside");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.Property(e => e.StartPoint).HasColumnName("start_point");

                entity.Property(e => e.StartPointDistanceSea).HasColumnName("start_point_distance_sea");

                entity.Property(e => e.TotalDistance).HasColumnName("total_distance");

                entity.Property(e => e.TrashCount).HasColumnName("trash_count");
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

                entity.Property(e => e.BlobName).HasColumnName("blob_name");

                entity.Property(e => e.ContainerUrl).HasColumnName("container_url");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Distance)
                    .HasColumnName("distance")
                    .HasColumnType("numeric");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.RiverName).HasColumnName("river_name");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            });

            modelBuilder.Entity<ChefLieu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("chef_lieu", "raw_data");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InseeCom).HasColumnName("insee_com");

                entity.Property(e => e.NomChf).HasColumnName("nom_chf");

                entity.Property(e => e.Statut).HasColumnName("statut");
            });

            modelBuilder.Entity<Commune>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("commune", "raw_data");

                entity.Property(e => e.CodeEpci).HasColumnName("code_epci");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InseeArr).HasColumnName("insee_arr");

                entity.Property(e => e.InseeCom).HasColumnName("insee_com");

                entity.Property(e => e.InseeDep).HasColumnName("insee_dep");

                entity.Property(e => e.InseeReg).HasColumnName("insee_reg");

                entity.Property(e => e.NomCom).HasColumnName("nom_com");

                entity.Property(e => e.NomComM).HasColumnName("nom_com_m");

                entity.Property(e => e.NomDep).HasColumnName("nom_dep");

                entity.Property(e => e.NomReg).HasColumnName("nom_reg");

                entity.Property(e => e.Population).HasColumnName("population");

                entity.Property(e => e.Statut).HasColumnName("statut");
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
            });

            modelBuilder.Entity<CoursDEau>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cours_d_eau", "raw_data");

                entity.HasIndex(e => e.Geometry)
                    .HasName("raw_data_cours_d_eau_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.Maree).HasColumnName("maree");

                entity.Property(e => e.Permanent).HasColumnName("permanent");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.Property(e => e.StatutTop).HasColumnName("statut_top");

                entity.Property(e => e.Toponyme).HasColumnName("toponyme");
            });

            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("departement", "raw_data");

                entity.HasIndex(e => e.Geometry)
                    .HasName("raw_data_departement_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InseeDep).HasColumnName("insee_dep");

                entity.Property(e => e.InseeReg).HasColumnName("insee_reg");

                entity.Property(e => e.NomDep).HasColumnName("nom_dep");
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

            modelBuilder.Entity<DetailHydrographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("detail_hydrographique", "raw_data");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Etat).HasColumnName("etat");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.NatDetail).HasColumnName("nat_detail");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.PrecPlani).HasColumnName("prec_plani");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.StatutTop).HasColumnName("statut_top");

                entity.Property(e => e.Toponyme).HasColumnName("toponyme");
            });

            modelBuilder.Entity<Epci>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("epci", "raw_data");

                entity.Property(e => e.CodeEpci).HasColumnName("code_epci");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NomEpci).HasColumnName("nom_epci");

                entity.Property(e => e.TypeEpci).HasColumnName("type_epci");
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.ToTable("media", "campaign");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.IdRefTrajectoryPointsFk);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Blobname)
                    .IsRequired()
                    .HasColumnName("blobname");

                entity.Property(e => e.Containerurl)
                    .IsRequired()
                    .HasColumnName("containerurl");

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

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.IdRefCampaignFkNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.IdRefCampaignFk)
                    .HasConstraintName("image_id_ref_campaign_fk_fkey");

                entity.HasOne(d => d.IdRefTrajectoryPointsFkNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.IdRefTrajectoryPointsFk)
                    .HasConstraintName("image_id_ref_trajectory_points_fk_fkey");
            });


            modelBuilder.Entity<LimiteTerreMer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("limite_terre_mer", "raw_data");

                entity.HasIndex(e => e.Geometry)
                    .HasName("raw_data_limite_terre_mer_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.CodePays).HasColumnName("code_pays");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Niveau).HasColumnName("niveau");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.PrecPlani).HasColumnName("prec_plani");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.SrcCoord).HasColumnName("src_coord");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.Property(e => e.TypeLimit).HasColumnName("type_limit");
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

           modelBuilder.Entity<Bi_Log>(entity =>
            {
                entity.ToTable("bi", "logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignId)
                    .HasColumnName("campaign_id");  
                        
                entity.HasOne(d => d.BiLogs_Campaign_CampaignFKNavigation)
                    .WithMany(p => p.Bi_Logs)
                    .HasForeignKey(d => d.CampaignId)
                    .HasConstraintName("bi_log_id_ref_campaign_campaign_fkey");

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
                    .HasConstraintName("etl_log_id_ref_campaign_campaign_fkey");
                
                entity.HasOne(d => d.EtlLogs_MediaFKNavigation)
                    .WithMany(p => p.EtlLogs)
                    .HasForeignKey(d => d.MediaId)
                    .HasConstraintName("etl_log_id_ref_media_fkey");

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

            modelBuilder.Entity<NoeudHydrographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("noeud_hydrographique", "raw_data");

                entity.HasIndex(e => e.Geometry)
                    .HasName("raw_data_noeud_hydrographique_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.Categorie).HasColumnName("categorie");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.CodePays).HasColumnName("code_pays");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCeAmon).HasColumnName("id_ce_amon");

                entity.Property(e => e.IdCeAval).HasColumnName("id_ce_aval");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.PrecAlti).HasColumnName("prec_alti");

                entity.Property(e => e.PrecPlani).HasColumnName("prec_plani");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.SrcAlti).HasColumnName("src_alti");

                entity.Property(e => e.SrcCoord).HasColumnName("src_coord");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.Property(e => e.StatutTop).HasColumnName("statut_top");

                entity.Property(e => e.Toponyme).HasColumnName("toponyme");
            });


            modelBuilder.Entity<PlanDEau>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("plan_d_eau", "raw_data");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.HautMax).HasColumnName("haut_max");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.Maree).HasColumnName("maree");

                entity.Property(e => e.ModeZMoy).HasColumnName("mode_z_moy");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.ObtHtMax).HasColumnName("obt_ht_max");

                entity.Property(e => e.Permanent).HasColumnName("permanent");

                entity.Property(e => e.PrecZMoy).HasColumnName("prec_z_moy");

                entity.Property(e => e.RefZMoy).HasColumnName("ref_z_moy");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.Property(e => e.StatutTop).HasColumnName("statut_top");

                entity.Property(e => e.Toponyme).HasColumnName("toponyme");

                entity.Property(e => e.ZMoy).HasColumnName("z_moy");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("region", "raw_data");

                entity.HasIndex(e => e.Geometry)
                    .HasName("raw_data_region_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InseeReg).HasColumnName("insee_reg");

                entity.Property(e => e.NomReg).HasColumnName("nom_reg");
            });

            modelBuilder.Entity<River_Referential>(entity =>
            {
                entity.ToTable("river", "referential");

                entity.HasIndex(e => e.IdRefCountryFk);

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

            modelBuilder.Entity<River_Bi>(entity =>
            {
                entity.ToTable("river", "bi");

                entity.HasIndex(e => e.Name)
                    .HasName("river_name");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("river_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountTrash).HasColumnName("count_trash");

                entity.Property(e => e.CountUniqueTrash).HasColumnName("count_unique_trash");

                entity.Property(e => e.DistanceMonitored).HasColumnName("distance_monitored");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.TheGeomMonitored).HasColumnName("the_geom_monitored");

                entity.Property(e => e.TrashPerKm)
                    .HasColumnName("trash_per_km")
                    .HasColumnType("numeric");
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

            modelBuilder.Entity<SurfaceHydrographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("surface_hydrographique", "raw_data");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.CodePays).HasColumnName("code_pays");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Etat).HasColumnName("etat");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCEau).HasColumnName("id_c_eau");

                entity.Property(e => e.IdEntTr).HasColumnName("id_ent_tr");

                entity.Property(e => e.IdPEau).HasColumnName("id_p_eau");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.NomCEau).HasColumnName("nom_c_eau");

                entity.Property(e => e.NomEntTr).HasColumnName("nom_ent_tr");

                entity.Property(e => e.NomPEau).HasColumnName("nom_p_eau");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.Persistanc).HasColumnName("persistanc");

                entity.Property(e => e.PosSol).HasColumnName("pos_sol");

                entity.Property(e => e.PrecAlti).HasColumnName("prec_alti");

                entity.Property(e => e.PrecPlani).HasColumnName("prec_plani");

                entity.Property(e => e.Salinite).HasColumnName("salinite");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.SrcAlti).HasColumnName("src_alti");

                entity.Property(e => e.SrcCoord).HasColumnName("src_coord");

                entity.Property(e => e.Statut).HasColumnName("statut");
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



            modelBuilder.Entity<ToponymieHydrographie>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("toponymie_hydrographie", "raw_data");

                entity.Property(e => e.Classe).HasColumnName("classe");

                entity.Property(e => e.DateTop).HasColumnName("date_top");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Graphie).HasColumnName("graphie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.StatutTop).HasColumnName("statut_top");
            });

            modelBuilder.Entity<Traces>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("traces", "raw_data");

                entity.Property(e => e.CampaignId).HasColumnName("campaign_id");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.File).HasColumnName("file");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Locomotion).HasColumnName("locomotion");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.River).HasColumnName("river");

                entity.Property(e => e.Riverside).HasColumnName("riverside");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserFirstName).HasColumnName("user_first_name");

                entity.Property(e => e.UserLastName).HasColumnName("user_last_name");
            });

            modelBuilder.Entity<TrajectoryPoint_Campaign>(entity =>
            {
                entity.ToTable("trajectory_point", "campaign");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.TheGeom)
                    .HasName("trajectory_point_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Distance).HasColumnName("distance");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.IdRefCampaignFk).HasColumnName("id_ref_campaign_fk");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.TimeDiff).HasColumnName("time_diff");

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

                entity.HasIndex(e => e.IdRefTrajectoryPointFk)
                    .HasName("trajectory_point_river_id_ref_trajectory_point_fk");

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

            modelBuilder.Entity<Trash_Bi>(entity =>
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

                entity.HasOne(d => d.IdRefTrashTypeFkNavigation)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.IdRefTrashTypeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trash_id_ref_trash_type_fk_fkey");
            });

            modelBuilder.Entity<Trash_Campaign>(entity =>
            {
                entity.ToTable("trash", "campaign");

                entity.HasIndex(e => e.IdRefCampaignFk);

                entity.HasIndex(e => e.IdRefImageFk);

                entity.HasIndex(e => e.IdRefModelFk);

                entity.HasIndex(e => e.IdRefTrashTypeFk);

                entity.HasIndex(e => e.TheGeom)
                    .HasName("trash_the_geom")
                    .HasMethod("gist");

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

                entity.HasOne(d => d.IdRefTrashTypeFkNavigation)
                    .WithMany(p => p.Trash1)
                    .HasForeignKey(d => d.IdRefTrashTypeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trash_id_ref_trash_type_fk_fkey");
            });

            modelBuilder.Entity<Trash_RawData>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("trash", "raw_data");

                entity.Property(e => e.CampaignId).HasColumnName("campaign_id");

                entity.Property(e => e.Elevation).HasColumnName("elevation");

                entity.Property(e => e.File).HasColumnName("file");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Locomotion).HasColumnName("locomotion");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.Object).HasColumnName("object");

                entity.Property(e => e.River).HasColumnName("river");

                entity.Property(e => e.Riverside).HasColumnName("riverside");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserFirstName).HasColumnName("user_first_name");

                entity.Property(e => e.UserLastName).HasColumnName("user_last_name");
            });

            modelBuilder.Entity<TrashRiver>(entity =>
            {
                entity.ToTable("trash_river", "bi");

                entity.HasIndex(e => e.ClosestPointTheGeom)
                    .HasName("trash_river_closest_point_the_geom")
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

            modelBuilder.Entity<TrashType>(entity =>
            {
                entity.ToTable("trash_type", "campaign");

                entity.HasIndex(e => e.Type)
                    .HasName("trash_type_type_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<TronconHydrographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("troncon_hydrographique", "raw_data");

                entity.HasIndex(e => e.Geometry)
                    .HasName("raw_data_troncon_hydrographique_geometry")
                    .HasMethod("gist");

                entity.Property(e => e.Bras).HasColumnName("bras");

                entity.Property(e => e.ClaOrdre).HasColumnName("cla_ordre");

                entity.Property(e => e.CodeCarth).HasColumnName("code_carth");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.CodePays).HasColumnName("code_pays");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.DateApp).HasColumnName("date_app");

                entity.Property(e => e.DateConf).HasColumnName("date_conf");

                entity.Property(e => e.DateCreat).HasColumnName("date_creat");

                entity.Property(e => e.DateMaj).HasColumnName("date_maj");

                entity.Property(e => e.Delimit).HasColumnName("delimit");

                entity.Property(e => e.Etat).HasColumnName("etat");

                entity.Property(e => e.Fictif).HasColumnName("fictif");

                entity.Property(e => e.Fosse).HasColumnName("fosse");

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCEau).HasColumnName("id_c_eau");

                entity.Property(e => e.IdEntTr).HasColumnName("id_ent_tr");

                entity.Property(e => e.IdSHydro).HasColumnName("id_s_hydro");

                entity.Property(e => e.IdSource).HasColumnName("id_source");

                entity.Property(e => e.Largeur).HasColumnName("largeur");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.Navigabl).HasColumnName("navigabl");

                entity.Property(e => e.NomCEau).HasColumnName("nom_c_eau");

                entity.Property(e => e.NomEntTr).HasColumnName("nom_ent_tr");

                entity.Property(e => e.NumOrdre).HasColumnName("num_ordre");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.PerOrdre).HasColumnName("per_ordre");

                entity.Property(e => e.Persistanc).HasColumnName("persistanc");

                entity.Property(e => e.PosSol).HasColumnName("pos_sol");

                entity.Property(e => e.PrecAlti).HasColumnName("prec_alti");

                entity.Property(e => e.PrecPlani).HasColumnName("prec_plani");

                entity.Property(e => e.ResCoulan).HasColumnName("res_coulan");

                entity.Property(e => e.Salinite).HasColumnName("salinite");

                entity.Property(e => e.SensEcoul).HasColumnName("sens_ecoul");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.SrcAlti).HasColumnName("src_alti");

                entity.Property(e => e.SrcCoord).HasColumnName("src_coord");

                entity.Property(e => e.Statut).HasColumnName("statut");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "campaign");

                entity.HasIndex(e => e.Firstname)
                    .HasName("user_firstname");

                entity.HasIndex(e => e.Lastname)
                    .HasName("user_lastname");

                entity.HasIndex(e => new { e.Firstname, e.Lastname })
                    .HasName("user_firstname_lastname_key")
                    .IsUnique();

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
            });

            modelBuilder.Entity<ImagesForLabelling>(entity =>
            {
                entity.ToTable("images_for_labelling", "label");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedOn).HasColumnName("createdon");

                entity.Property(e => e.Filename).HasColumnName("filename");

                entity.Property(e => e.View).HasColumnName("view");

                entity.Property(e => e.ImageQuality).HasColumnName("image_quality");

                entity.Property(e => e.ContainerUrl).HasColumnName("container_url");

                entity.Property(e => e.BlobName).HasColumnName("blob_name");

                // Déclaration des FK 
                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.UserImagesForLabellings)
                    .HasForeignKey(d => d.IdCreatorFk)
                    .HasConstraintName("id_creator_fk");
            });

            modelBuilder.Entity<BoundingBoxes>(entity =>
           {
               entity.ToTable("bounding_boxes", "label");

               entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasDefaultValueSql("uuid_generate_v4()");

               entity.Property(e => e.CreatedOn).HasColumnName("createdon");

               entity.Property(e => e.LocationX).HasColumnName("locationX");

               entity.Property(e => e.LocationY).HasColumnName("locationY");

               entity.Property(e => e.Width).HasColumnName("width");

               entity.Property(e => e.Height).HasColumnName("height");


                // Déclaration des FK 
                entity.HasOne(d => d.Creator)
                   .WithMany(p => p.UserBoundingBoxesNavigation)
                   .HasForeignKey(d => d.IdCreatorFk)
                   .HasConstraintName("id_creator_fk");

               entity.HasOne(d => d.TrashType)
                   .WithMany(p => p.TrashTypeBoundingBoxesNavigation)
                   .HasForeignKey(d => d.IdRefTrashTypeFk)
                   .HasConstraintName("id_ref_trash_type_fk");

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
