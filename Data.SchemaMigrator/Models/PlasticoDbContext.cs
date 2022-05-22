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

        public virtual DbSet<Campaign_Campaign> Campaign_Campaign { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Bi_Log> Bi_Logs { get; set; }
        public virtual DbSet<Bi_Log> Etl_Logs { get; set; }
        public virtual DbSet<AiModel> AiModel { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Test2> Test2 { get; set; }
        public virtual DbSet<TrajectoryPoint_Campaign> TrajectoryPoint_Campaign { get; set; }
        public virtual DbSet<Trash_Campaign> Trash_Campaign { get; set; }
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
                .HasPostgresExtension("pgrouting")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_topology")
                .HasPostgresExtension("uuid-ossp");

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

                entity.HasIndex(e => e.IdRefCampaignFk);

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
