using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.SchemaMigrator.Models.PgContext.Campaign
{
    public partial class Pg_CampaignDataContext : DbContext
    {
        public Pg_CampaignDataContext()
        {
        }

        public Pg_CampaignDataContext(DbContextOptions<Pg_CampaignDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        
        #pragma warning disable CS0114
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<TrajectoryPoint> TrajectoryPoint { get; set; }
        public virtual DbSet<Trash> Trash { get; set; }
        public virtual DbSet<TrashType> TrashType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.local.json").Build();
            var cs = configuration.GetConnectionString("PostgreSql");
            optionsBuilder.UseNpgsql(cs, x=> x.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_topology")
                .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("campaign", "campaign");

                entity.HasIndex(e => e.Id)
                    .HasName("campaign_id");

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
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.IdRefModelFk)
                    .HasConstraintName("campaign_id_ref_model_fk_fkey");

                entity.HasOne(d => d.IdRefUserFkNavigation)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.IdRefUserFk)
                    .HasConstraintName("campaign_id_ref_user_fk_fkey");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image", "campaign");

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

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model", "campaign");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Createdon).HasColumnName("createdon");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<TrajectoryPoint>(entity =>
            {
                entity.ToTable("trajectory_point", "campaign");

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
                    .WithMany(p => p.TrajectoryPoint)
                    .HasForeignKey(d => d.IdRefCampaignFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trajectory_point_id_ref_campaign_fk_fkey");
            });

            modelBuilder.Entity<Trash>(entity =>
            {
                entity.ToTable("trash", "campaign");

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
