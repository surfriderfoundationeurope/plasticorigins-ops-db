using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.SchemaMigrator.Models.PgContext.Public
{
    public partial class Pg_PublicDataContext : DbContext
    {
        public Pg_PublicDataContext()
        {
        }

        public Pg_PublicDataContext(DbContextOptions<Pg_PublicDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CoursDEau> CoursDEau { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<HydroNode06> HydroNode06 { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<LimitsLandSea> LimitsLandSea { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<MonitoringBlockedQueries> MonitoringBlockedQueries { get; set; }
        public virtual DbSet<MonitoringRunningQueries> MonitoringRunningQueries { get; set; }
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<Node> Node { get; set; }
        public virtual DbSet<PgBuffercache> PgBuffercache { get; set; }
        public virtual DbSet<PgStatStatements> PgStatStatements { get; set; }
        public virtual DbSet<River> River { get; set; }
        public virtual DbSet<River06> River06 { get; set; }
        public virtual DbSet<River06Ce> River06Ce { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SurfaceHydrographique> SurfaceHydrographique { get; set; }
        public virtual DbSet<TrajectoryPoint> TrajectoryPoint { get; set; }
        public virtual DbSet<TrajectoryPointRiver> TrajectoryPointRiver { get; set; }
        public virtual DbSet<Trash> Trash { get; set; }
        public virtual DbSet<TrashRiver> TrashRiver { get; set; }
        public virtual DbSet<TrashType> TrashType { get; set; }
        public virtual DbSet<UserCampaign> UserCampaign { get; set; }

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
                entity.ToTable("campaign");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.AvgSpeed).HasColumnName("avg_speed");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.DistanceStartEnd).HasColumnName("distance_start_end");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.EndingPointTheGeom).HasColumnName("ending_point_the_geom");

                entity.Property(e => e.File).HasColumnName("file");

                entity.Property(e => e.IdRefUserFk).HasColumnName("id_ref_user_fk");

                entity.Property(e => e.Isaidriven).HasColumnName("isaidriven");

                entity.Property(e => e.Locomotion)
                    .IsRequired()
                    .HasColumnName("locomotion");

                entity.Property(e => e.Remark).HasColumnName("remark");

                entity.Property(e => e.Riverside).HasColumnName("riverside");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.StartingPointTheGeom).HasColumnName("starting_point_the_geom");

                entity.Property(e => e.TotalDistance).HasColumnName("total_distance");

                entity.HasOne(d => d.IdRefUserFkNavigation)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.IdRefUserFk)
                    .HasConstraintName("campaign_id_ref_user_fk_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

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

                entity.ToTable("cours_d_eau");

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

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.Code)
                    .HasName("department_code");

                entity.HasIndex(e => e.Name)
                    .HasName("department_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.TheGeom)
                    .HasName("department_the_geom")
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

            modelBuilder.Entity<HydroNode06>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hydro_node_06");

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

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Toponyme).HasColumnName("toponyme");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

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

            modelBuilder.Entity<LimitsLandSea>(entity =>
            {
                entity.ToTable("limits_land_sea");

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

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<MonitoringBlockedQueries>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("monitoring_blocked_queries");

                entity.Property(e => e.BlockedBy).HasColumnName("blocked_by");

                entity.Property(e => e.BlockedQuery).HasColumnName("blocked_query");

                entity.Property(e => e.Pid).HasColumnName("pid");
            });

            modelBuilder.Entity<MonitoringRunningQueries>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("monitoring_running_queries");

                entity.Property(e => e.ApplicationName).HasColumnName("application_name");

                entity.Property(e => e.BackendStart)
                    .HasColumnName("backend_start")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.QueryStart)
                    .HasColumnName("query_start")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.WaitEvent).HasColumnName("wait_event");

                entity.Property(e => e.WaitEventType).HasColumnName("wait_event_type");
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.ToTable("municipality");

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

            modelBuilder.Entity<Node>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("node");

                entity.HasIndex(e => e.TheGeom)
                    .HasName("node_the_geom")
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

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Toponyme).HasColumnName("toponyme");
            });

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnName("reldatabase")
                    .HasColumnType("oid");

                entity.Property(e => e.Relfilenode)
                    .HasColumnName("relfilenode")
                    .HasColumnType("oid");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnName("reltablespace")
                    .HasColumnType("oid");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatements>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnName("dbid")
                    .HasColumnType("oid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("oid");
            });

            modelBuilder.Entity<River>(entity =>
            {
                entity.ToTable("river");

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

            modelBuilder.Entity<River06>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("river_06");

                entity.Property(e => e.Bras).HasColumnName("bras");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CodeHydro).HasColumnName("code_hydro");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRefCountryFk).HasColumnName("id_ref_country_fk");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Nature).HasColumnName("nature");

                entity.Property(e => e.Origine).HasColumnName("origine");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            });

            modelBuilder.Entity<River06Ce>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("river_06_ce");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

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

            modelBuilder.Entity<SurfaceHydrographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("surface_hydrographique");

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

            modelBuilder.Entity<TrajectoryPoint>(entity =>
            {
                entity.ToTable("trajectory_point");

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

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.TimeDiff).HasColumnName("time_diff");

                entity.HasOne(d => d.IdRefCampaignFkNavigation)
                    .WithMany(p => p.TrajectoryPoint)
                    .HasForeignKey(d => d.IdRefCampaignFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trajectory_point_id_ref_campaign_fk_fkey");
            });

            modelBuilder.Entity<TrajectoryPointRiver>(entity =>
            {
                entity.ToTable("trajectory_point_river");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClosestPointTheGeom)
                    .IsRequired()
                    .HasColumnName("closest_point_the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.DistanceRiverTrajectoryPoint).HasColumnName("distance_river_trajectory_point");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrajectoryPointFk).HasColumnName("id_ref_trajectory_point_fk");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.ProjectionTrajectoryPointRiverTheGeom)
                    .IsRequired()
                    .HasColumnName("projection_trajectory_point_river_the_geom");

                entity.Property(e => e.RiverTheGeom)
                    .IsRequired()
                    .HasColumnName("river_the_geom");

                entity.Property(e => e.TrajectoryPointTheGeom)
                    .IsRequired()
                    .HasColumnName("trajectory_point_the_geom");

                entity.HasOne(d => d.IdRefRiverFkNavigation)
                    .WithMany(p => p.TrajectoryPointRiver)
                    .HasForeignKey(d => d.IdRefRiverFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trajectory_point_river_id_ref_river_fk_fkey");

                entity.HasOne(d => d.IdRefTrajectoryPointFkNavigation)
                    .WithMany(p => p.TrajectoryPointRiver)
                    .HasForeignKey(d => d.IdRefTrajectoryPointFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trajectory_point_river_id_ref_trajectory_point_fk_fkey");
            });

            modelBuilder.Entity<Trash>(entity =>
            {
                entity.ToTable("trash");

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

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.TheGeom).HasColumnName("the_geom");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.IdRefCampaignFkNavigation)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.IdRefCampaignFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trash_id_ref_campaign_fk_fkey");

                entity.HasOne(d => d.IdRefImageFkNavigation)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.IdRefImageFk)
                    .HasConstraintName("trash_id_ref_image_fk_fkey");

                entity.HasOne(d => d.IdRefModelFkNavigation)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.IdRefModelFk)
                    .HasConstraintName("trash_id_ref_model_fk_fkey");

                entity.HasOne(d => d.IdRefTrashTypeFkNavigation)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.IdRefTrashTypeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trash_id_ref_trash_type_fk_fkey");
            });

            modelBuilder.Entity<TrashRiver>(entity =>
            {
                entity.ToTable("trash_river");

                entity.HasIndex(e => e.ClosestPointTheGeom)
                    .HasName("trash_river_closest_point_the_geom")
                    .HasMethod("gist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClosestPointTheGeom)
                    .IsRequired()
                    .HasColumnName("closest_point_the_geom");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.DistanceRiverTrash).HasColumnName("distance_river_trash");

                entity.Property(e => e.IdRefRiverFk).HasColumnName("id_ref_river_fk");

                entity.Property(e => e.IdRefTrashFk).HasColumnName("id_ref_trash_fk");

                entity.Property(e => e.Importance).HasColumnName("importance");

                entity.Property(e => e.ProjectionTrashRiverTheGeom)
                    .IsRequired()
                    .HasColumnName("projection_trash_river_the_geom");

                entity.Property(e => e.RiverTheGeom)
                    .IsRequired()
                    .HasColumnName("river_the_geom");

                entity.Property(e => e.TrashTheGeom)
                    .IsRequired()
                    .HasColumnName("trash_the_geom");

                entity.HasOne(d => d.IdRefRiverFkNavigation)
                    .WithMany(p => p.TrashRiver)
                    .HasForeignKey(d => d.IdRefRiverFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trash_river_id_ref_river_fk_fkey");

                entity.HasOne(d => d.IdRefTrashFkNavigation)
                    .WithMany(p => p.TrashRiver)
                    .HasForeignKey(d => d.IdRefTrashFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trash_river_id_ref_trash_fk_fkey");
            });

            modelBuilder.Entity<TrashType>(entity =>
            {
                entity.ToTable("trash_type");

                entity.HasIndex(e => e.Type)
                    .HasName("trash_type_type_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<UserCampaign>(entity =>
            {
                entity.ToTable("user_campaign");

                entity.HasIndex(e => e.Firstname)
                    .HasName("user_campaign_firstname");

                entity.HasIndex(e => e.Lastname)
                    .HasName("user_campaign_lastname");

                entity.HasIndex(e => new { e.Firstname, e.Lastname })
                    .HasName("user_campaign_firstname_lastname_key")
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

                entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");

                entity.Property(e => e.Yearofbirth)
                    .HasColumnName("yearofbirth")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
