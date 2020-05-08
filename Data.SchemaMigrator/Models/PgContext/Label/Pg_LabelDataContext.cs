using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.SchemaMigrator.Models.PgContext.Label
{
    public partial class Pg_LabelDataContext : DbContext
    {
         public Pg_LabelDataContext()
        {
        }

        public Pg_LabelDataContext(DbContextOptions<Pg_LabelDataContext> options)
            : base(options)
        {
        }

        /* Déclaration des tables */
        public virtual DbSet<ImagesForLabelling> ImagesForLabelling { get; set; }
        public virtual DbSet<BoundingBoxes> BoundingBoxes { get; set; }
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
                    .WithMany(p => p.ImagesForLabellings)
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