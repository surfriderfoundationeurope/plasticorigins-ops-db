﻿// <auto-generated />
using System;
using System.Collections;
using Data.SchemaMigrator.Models.PgContext.Campaign;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations.Campaign
{
    [DbContext(typeof(Pg_CampaignDataContext))]
    partial class Pg_CampaignDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:pg_buffercache", ",,")
                .HasAnnotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .HasAnnotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .HasAnnotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .HasAnnotation("Npgsql:PostgresExtension:postgis", ",,")
                .HasAnnotation("Npgsql:PostgresExtension:postgis_topology", ",,")
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("BlobName")
                        .HasColumnName("blob_name")
                        .HasColumnType("text");

                    b.Property<string>("ContainerUrl")
                        .HasColumnName("container_url")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Createdon")
                        .HasColumnName("createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("IdRefModelFk")
                        .HasColumnName("id_ref_model_fk")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdRefUserFk")
                        .HasColumnName("id_ref_user_fk")
                        .HasColumnType("uuid");

                    b.Property<bool?>("Isaidriven")
                        .HasColumnName("isaidriven")
                        .HasColumnType("boolean");

                    b.Property<string>("Locomotion")
                        .IsRequired()
                        .HasColumnName("locomotion")
                        .HasColumnType("text");

                    b.Property<string>("Remark")
                        .HasColumnName("remark")
                        .HasColumnType("text");

                    b.Property<string>("Riverside")
                        .HasColumnName("riverside")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("campaign_id");

                    b.HasIndex("IdRefModelFk");

                    b.HasIndex("IdRefUserFk");

                    b.ToTable("campaign","campaign");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Blobname")
                        .IsRequired()
                        .HasColumnName("blobname")
                        .HasColumnType("text");

                    b.Property<string>("Containerurl")
                        .IsRequired()
                        .HasColumnName("containerurl")
                        .HasColumnType("text");

                    b.Property<string>("Createdby")
                        .IsRequired()
                        .HasColumnName("createdby")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Createdon")
                        .HasColumnName("createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnName("filename")
                        .HasColumnType("text");

                    b.Property<Guid?>("IdRefCampaignFk")
                        .HasColumnName("id_ref_campaign_fk")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdRefTrajectoryPointsFk")
                        .HasColumnName("id_ref_trajectory_points_fk")
                        .HasColumnType("uuid");

                    b.Property<BitArray>("Isdeleted")
                        .IsRequired()
                        .HasColumnName("isdeleted")
                        .HasColumnType("bit(1)");

                    b.Property<DateTime?>("Time")
                        .HasColumnName("time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Version")
                        .HasColumnName("version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdRefCampaignFk");

                    b.HasIndex("IdRefTrajectoryPointsFk");

                    b.ToTable("image","campaign");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("Createdon")
                        .HasColumnName("createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("Version")
                        .HasColumnName("version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("model","campaign");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.TrajectoryPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("Createdon")
                        .HasColumnName("createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("Distance")
                        .HasColumnName("distance")
                        .HasColumnType("double precision");

                    b.Property<double?>("Elevation")
                        .HasColumnName("elevation")
                        .HasColumnType("double precision");

                    b.Property<Guid>("IdRefCampaignFk")
                        .HasColumnName("id_ref_campaign_fk")
                        .HasColumnType("uuid");

                    b.Property<double?>("Lat")
                        .HasColumnName("lat")
                        .HasColumnType("double precision");

                    b.Property<double?>("Lon")
                        .HasColumnName("lon")
                        .HasColumnType("double precision");

                    b.Property<double?>("Speed")
                        .HasColumnName("speed")
                        .HasColumnType("double precision");

                    b.Property<Geometry>("TheGeom")
                        .HasColumnName("the_geom")
                        .HasColumnType("geometry");

                    b.Property<DateTime?>("Time")
                        .HasColumnName("time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<TimeSpan?>("TimeDiff")
                        .HasColumnName("time_diff")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("IdRefCampaignFk");

                    b.HasIndex("TheGeom")
                        .HasName("trajectory_point_the_geom")
                        .HasAnnotation("Npgsql:IndexMethod", "gist");

                    b.ToTable("trajectory_point","campaign");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.Trash", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("BrandType")
                        .HasColumnName("brand_type")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Createdon")
                        .HasColumnName("createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double?>("Elevation")
                        .HasColumnName("elevation")
                        .HasColumnType("double precision");

                    b.Property<Guid>("IdRefCampaignFk")
                        .HasColumnName("id_ref_campaign_fk")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdRefImageFk")
                        .HasColumnName("id_ref_image_fk")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdRefModelFk")
                        .HasColumnName("id_ref_model_fk")
                        .HasColumnType("uuid");

                    b.Property<int>("IdRefTrashTypeFk")
                        .HasColumnName("id_ref_trash_type_fk")
                        .HasColumnType("integer");

                    b.Property<double?>("Lat")
                        .HasColumnName("lat")
                        .HasColumnType("double precision");

                    b.Property<double?>("Lon")
                        .HasColumnName("lon")
                        .HasColumnType("double precision");

                    b.Property<double?>("Precision")
                        .HasColumnName("precision")
                        .HasColumnType("double precision");

                    b.Property<Geometry>("TheGeom")
                        .HasColumnName("the_geom")
                        .HasColumnType("geometry");

                    b.Property<DateTime?>("Time")
                        .HasColumnName("time")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("IdRefCampaignFk");

                    b.HasIndex("IdRefImageFk");

                    b.HasIndex("IdRefModelFk");

                    b.HasIndex("IdRefTrashTypeFk");

                    b.HasIndex("TheGeom")
                        .HasName("trash_the_geom")
                        .HasAnnotation("Npgsql:IndexMethod", "gist");

                    b.ToTable("trash","campaign");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.TrashType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Brand")
                        .HasColumnName("brand")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique()
                        .HasName("trash_type_type_key");

                    b.ToTable("trash_type","campaign");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime?>("Createdon")
                        .HasColumnName("createdon")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("text");

                    b.Property<bool>("Emailconfirmed")
                        .HasColumnName("emailconfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Experience")
                        .HasColumnName("experience")
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .HasColumnName("firstname")
                        .HasColumnType("text");

                    b.Property<bool>("Isdeleted")
                        .HasColumnName("isdeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .HasColumnName("lastname")
                        .HasColumnType("text");

                    b.Property<string>("Passwordhash")
                        .HasColumnName("passwordhash")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Yearofbirth")
                        .HasColumnName("yearofbirth")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("Firstname")
                        .HasName("user_firstname");

                    b.HasIndex("Lastname")
                        .HasName("user_lastname");

                    b.HasIndex("Firstname", "Lastname")
                        .IsUnique()
                        .HasName("user_firstname_lastname_key");

                    b.ToTable("user","campaign");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.Campaign", b =>
                {
                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.Model", "IdRefModelFkNavigation")
                        .WithMany("Campaign")
                        .HasForeignKey("IdRefModelFk")
                        .HasConstraintName("campaign_id_ref_model_fk_fkey");

                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.User", "IdRefUserFkNavigation")
                        .WithMany("Campaign")
                        .HasForeignKey("IdRefUserFk")
                        .HasConstraintName("campaign_id_ref_user_fk_fkey");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.Image", b =>
                {
                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.Campaign", "IdRefCampaignFkNavigation")
                        .WithMany("Image")
                        .HasForeignKey("IdRefCampaignFk")
                        .HasConstraintName("image_id_ref_campaign_fk_fkey");

                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.TrajectoryPoint", "IdRefTrajectoryPointsFkNavigation")
                        .WithMany("Image")
                        .HasForeignKey("IdRefTrajectoryPointsFk")
                        .HasConstraintName("image_id_ref_trajectory_points_fk_fkey");
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.TrajectoryPoint", b =>
                {
                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.Campaign", "IdRefCampaignFkNavigation")
                        .WithMany("TrajectoryPoint")
                        .HasForeignKey("IdRefCampaignFk")
                        .HasConstraintName("trajectory_point_id_ref_campaign_fk_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("Data.SchemaMigrator.Models.PgContext.Campaign.Trash", b =>
                {
                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.Campaign", "IdRefCampaignFkNavigation")
                        .WithMany("Trash")
                        .HasForeignKey("IdRefCampaignFk")
                        .HasConstraintName("trash_id_ref_campaign_fk_fkey")
                        .IsRequired();

                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.Image", "IdRefImageFkNavigation")
                        .WithMany("Trash")
                        .HasForeignKey("IdRefImageFk")
                        .HasConstraintName("trash_id_ref_image_fk_fkey");

                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.Model", "IdRefModelFkNavigation")
                        .WithMany("Trash")
                        .HasForeignKey("IdRefModelFk")
                        .HasConstraintName("trash_id_ref_model_fk_fkey");

                    b.HasOne("Data.SchemaMigrator.Models.PgContext.Campaign.TrashType", "IdRefTrashTypeFkNavigation")
                        .WithMany("Trash")
                        .HasForeignKey("IdRefTrashTypeFk")
                        .HasConstraintName("trash_id_ref_trash_type_fk_fkey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
