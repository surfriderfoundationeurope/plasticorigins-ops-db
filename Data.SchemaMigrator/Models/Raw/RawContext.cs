using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.SchemaMigrator.Models.Raw
{
    public partial class RawContext : DbContext
    {
        public RawContext()
        {
        }

        public RawContext(DbContextOptions<RawContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.local.json")
                .AddAzureAppConfiguration(Environment.GetEnvironmentVariable("AzureSQLServerConnectionString"))
                .Build();
            
            var rawContextCs = configuration["SurfriderDb:AzureSQLServer"] ?? configuration.GetConnectionString("RawDatabase");
            optionsBuilder.UseSqlServer(rawContextCs);
        }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignImageAssoc> CampaignImageAssoc { get; set; }
        public virtual DbSet<CampaignStaff> CampaignStaff { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<River> River { get; set; }
        public virtual DbSet<Trash> Trash { get; set; }
        public virtual DbSet<TrashType> TrashType { get; set; }
        public virtual DbSet<User> User { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsAidriven).HasColumnName("IsAIDriven");

                entity.Property(e => e.Locomotion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Remark).IsUnicode(false);

                entity.Property(e => e.RiverId).HasColumnType("numeric(8, 0)");

                entity.HasOne(d => d.River)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.RiverId)
                    .HasConstraintName("FK__Campaign__RiverI__282DF8C2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Campaign__UserId__2B0A656D");
            });

            modelBuilder.Entity<CampaignImageAssoc>(entity =>
            {
                entity.HasKey(e => new { e.CampaignId, e.ImageId })
                    .HasName("PK__Campaign__E80FE5E951C5BC76");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignImageAssoc)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CampaignI__Campa__6EF57B66");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.CampaignImageAssoc)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CampaignI__Image__6FE99F9F");
            });

            modelBuilder.Entity<CampaignStaff>(entity =>
            {
                entity.HasKey(e => new { e.CampaignId, e.UserId })
                    .HasName("PK__Campaign__EE26065D3CBEF659");

                entity.ToTable("Campaign_Staff");

                entity.Property(e => e.HasBeenTrained)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsStaff)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.CampaignStaff)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Campaign___Campa__3E1D39E1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CampaignStaff)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Campaign___UserI__3F115E1A");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BlobName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ContainerUrl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<River>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__River__C1F8DC59ACD56E3A");

                entity.Property(e => e.Cid)
                    .HasColumnName("CID")
                    .HasColumnType("numeric(8, 0)");

                entity.Property(e => e.Candidat)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.CodeEntite)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(86)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trash>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AiVersion)
                    .HasColumnName("AI_Version")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Aiversion1)
                    .HasColumnName("AIVersion")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BrandType)
                    .HasColumnName("Brand_Type")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Campaign)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.CampaignId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trash__CampaignI__619B8048");

                entity.HasOne(d => d.RelatedImage)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.RelatedImageId)
                    .HasConstraintName("FK__Trash__RelatedIm__32AB8735");

                entity.HasOne(d => d.TrashType)
                    .WithMany(p => p.Trash)
                    .HasForeignKey(d => d.TrashTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trash__TrashType__160F4887");
            });

            modelBuilder.Entity<TrashType>(entity =>
            {
                entity.ToTable("Trash_Type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirmed)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Experience)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
