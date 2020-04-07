using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.SchemaMigrator.Models.PgContext.RawData
{
    public partial class Pg_RawDataContext : DbContext
    {
        public Pg_RawDataContext()
        {
        }

        public Pg_RawDataContext(DbContextOptions<Pg_RawDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArrondissementDepartemental> ArrondissementDepartemental { get; set; }
        public virtual DbSet<BassinVersantTopographique> BassinVersantTopographique { get; set; }
        public virtual DbSet<ChefLieu> ChefLieu { get; set; }
        public virtual DbSet<Commune> Commune { get; set; }
        public virtual DbSet<CoursDEau> CoursDEau { get; set; }
        public virtual DbSet<Departement> Departement { get; set; }
        public virtual DbSet<DetailHydrographique> DetailHydrographique { get; set; }
        public virtual DbSet<LimiteTerreMer> LimiteTerreMer { get; set; }
        public virtual DbSet<NoeudHydrographique> NoeudHydrographique { get; set; }
        public virtual DbSet<PlanDEau> PlanDEau { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<SurfaceHydrographique> SurfaceHydrographique { get; set; }
        public virtual DbSet<ToponymieHydrographie> ToponymieHydrographie { get; set; }
        public virtual DbSet<Traces> Traces { get; set; }
        public virtual DbSet<Trash> Trash { get; set; }
        public virtual DbSet<TronconHydrographique> TronconHydrographique { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Program.GetConnectionString(), x => x.UseNetTopologySuite());
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

            modelBuilder.Entity<CoursDEau>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("cours_d_eau", "raw_data");

                entity.HasIndex(e => e.Id)
                    .HasName("raw_data_cours_d_eau_id");

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

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InseeDep).HasColumnName("insee_dep");

                entity.Property(e => e.InseeReg).HasColumnName("insee_reg");

                entity.Property(e => e.NomDep).HasColumnName("nom_dep");
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

            modelBuilder.Entity<LimiteTerreMer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("limite_terre_mer", "raw_data");

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

            modelBuilder.Entity<NoeudHydrographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("noeud_hydrographique", "raw_data");

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

                entity.Property(e => e.Geometry).HasColumnName("geometry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InseeReg).HasColumnName("insee_reg");

                entity.Property(e => e.NomReg).HasColumnName("nom_reg");
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

            modelBuilder.Entity<Trash>(entity =>
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

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.UserFirstName).HasColumnName("user_first_name");

                entity.Property(e => e.UserLastName).HasColumnName("user_last_name");
            });

            modelBuilder.Entity<TronconHydrographique>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("troncon_hydrographique", "raw_data");

                entity.HasIndex(e => e.IdCEau)
                    .HasName("raw_data_troncon_hydrographique_id_c_eau");

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
                entity.HasNoKey();

                entity.ToTable("user", "raw_data");

                entity.Property(e => e.Column).HasColumnName("?column?");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
