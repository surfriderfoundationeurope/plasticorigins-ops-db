using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations.Label
{
    public partial class AddLabelSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "label");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_buffercache", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis_topology", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Model",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Version = table.Column<int>(nullable: true),
                    Createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrashType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrashType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Emailconfirmed = table.Column<bool>(nullable: false),
                    Passwordhash = table.Column<string>(nullable: true),
                    Yearofbirth = table.Column<DateTime>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    Isdeleted = table.Column<bool>(nullable: false),
                    Createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Locomotion = table.Column<string>(nullable: true),
                    Isaidriven = table.Column<bool>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    IdRefUserFk = table.Column<Guid>(nullable: true),
                    Riverside = table.Column<string>(nullable: true),
                    ContainerUrl = table.Column<string>(nullable: true),
                    BlobName = table.Column<string>(nullable: true),
                    IdRefModelFk = table.Column<Guid>(nullable: true),
                    Createdon = table.Column<DateTime>(nullable: true),
                    IdRefModelFkNavigationId = table.Column<Guid>(nullable: true),
                    IdRefUserFkNavigationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_Model_IdRefModelFkNavigationId",
                        column: x => x.IdRefModelFkNavigationId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campaign_User_IdRefUserFkNavigationId",
                        column: x => x.IdRefUserFkNavigationId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "images_for_labelling",
                schema: "label",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdCreatorFk = table.Column<Guid>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    filename = table.Column<string>(nullable: true),
                    view = table.Column<string>(nullable: true),
                    image_quality = table.Column<string>(nullable: true),
                    Context = table.Column<string>(nullable: true),
                    container_url = table.Column<string>(nullable: true),
                    blob_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images_for_labelling", x => x.id);
                    table.ForeignKey(
                        name: "id_creator_fk",
                        column: x => x.IdCreatorFk,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrajectoryPoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TheGeom = table.Column<Geometry>(nullable: true),
                    IdRefCampaignFk = table.Column<Guid>(nullable: false),
                    Elevation = table.Column<double>(nullable: true),
                    Distance = table.Column<double>(nullable: true),
                    TimeDiff = table.Column<TimeSpan>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true),
                    Speed = table.Column<double>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lon = table.Column<double>(nullable: true),
                    Createdon = table.Column<DateTime>(nullable: true),
                    IdRefCampaignFkNavigationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrajectoryPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrajectoryPoint_Campaign_IdRefCampaignFkNavigationId",
                        column: x => x.IdRefCampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bounding_boxes",
                schema: "label",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdCreatorFk = table.Column<Guid>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    IdRefTrashTypeFk = table.Column<int>(nullable: false),
                    IdRefImagesForLabelling = table.Column<Guid>(nullable: false),
                    locationX = table.Column<int>(nullable: false),
                    locationY = table.Column<int>(nullable: false),
                    width = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bounding_boxes", x => x.id);
                    table.ForeignKey(
                        name: "id_creator_fk",
                        column: x => x.IdCreatorFk,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "id_ref_images_for_labelling_fk",
                        column: x => x.IdRefImagesForLabelling,
                        principalSchema: "label",
                        principalTable: "images_for_labelling",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "id_ref_trash_type_fk",
                        column: x => x.IdRefTrashTypeFk,
                        principalTable: "TrashType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Filename = table.Column<string>(nullable: true),
                    Blobname = table.Column<string>(nullable: true),
                    Containerurl = table.Column<string>(nullable: true),
                    Createdby = table.Column<string>(nullable: true),
                    Isdeleted = table.Column<BitArray>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    IdRefCampaignFk = table.Column<Guid>(nullable: true),
                    IdRefTrajectoryPointsFk = table.Column<Guid>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true),
                    Createdon = table.Column<DateTime>(nullable: true),
                    IdRefCampaignFkNavigationId = table.Column<Guid>(nullable: true),
                    IdRefTrajectoryPointsFkNavigationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Campaign_IdRefCampaignFkNavigationId",
                        column: x => x.IdRefCampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_TrajectoryPoint_IdRefTrajectoryPointsFkNavigationId",
                        column: x => x.IdRefTrajectoryPointsFkNavigationId,
                        principalTable: "TrajectoryPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trash",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdRefCampaignFk = table.Column<Guid>(nullable: false),
                    TheGeom = table.Column<Geometry>(nullable: true),
                    Elevation = table.Column<double>(nullable: true),
                    IdRefTrashTypeFk = table.Column<int>(nullable: false),
                    Precision = table.Column<double>(nullable: true),
                    IdRefModelFk = table.Column<Guid>(nullable: true),
                    BrandType = table.Column<string>(nullable: true),
                    IdRefImageFk = table.Column<Guid>(nullable: true),
                    Time = table.Column<DateTime>(nullable: true),
                    Lat = table.Column<double>(nullable: true),
                    Lon = table.Column<double>(nullable: true),
                    Createdon = table.Column<DateTime>(nullable: true),
                    IdRefCampaignFkNavigationId = table.Column<Guid>(nullable: true),
                    IdRefImageFkNavigationId = table.Column<Guid>(nullable: true),
                    IdRefModelFkNavigationId = table.Column<Guid>(nullable: true),
                    IdRefTrashTypeFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trash_Campaign_IdRefCampaignFkNavigationId",
                        column: x => x.IdRefCampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trash_Image_IdRefImageFkNavigationId",
                        column: x => x.IdRefImageFkNavigationId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trash_Model_IdRefModelFkNavigationId",
                        column: x => x.IdRefModelFkNavigationId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trash_TrashType_IdRefTrashTypeFkNavigationId",
                        column: x => x.IdRefTrashTypeFkNavigationId,
                        principalTable: "TrashType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_IdRefModelFkNavigationId",
                table: "Campaign",
                column: "IdRefModelFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_IdRefUserFkNavigationId",
                table: "Campaign",
                column: "IdRefUserFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IdRefCampaignFkNavigationId",
                table: "Image",
                column: "IdRefCampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IdRefTrajectoryPointsFkNavigationId",
                table: "Image",
                column: "IdRefTrajectoryPointsFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrajectoryPoint_IdRefCampaignFkNavigationId",
                table: "TrajectoryPoint",
                column: "IdRefCampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trash_IdRefCampaignFkNavigationId",
                table: "Trash",
                column: "IdRefCampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trash_IdRefImageFkNavigationId",
                table: "Trash",
                column: "IdRefImageFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trash_IdRefModelFkNavigationId",
                table: "Trash",
                column: "IdRefModelFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trash_IdRefTrashTypeFkNavigationId",
                table: "Trash",
                column: "IdRefTrashTypeFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_bounding_boxes_IdCreatorFk",
                schema: "label",
                table: "bounding_boxes",
                column: "IdCreatorFk");

            migrationBuilder.CreateIndex(
                name: "IX_bounding_boxes_IdRefImagesForLabelling",
                schema: "label",
                table: "bounding_boxes",
                column: "IdRefImagesForLabelling");

            migrationBuilder.CreateIndex(
                name: "IX_bounding_boxes_IdRefTrashTypeFk",
                schema: "label",
                table: "bounding_boxes",
                column: "IdRefTrashTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_images_for_labelling_IdCreatorFk",
                schema: "label",
                table: "images_for_labelling",
                column: "IdCreatorFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trash");

            migrationBuilder.DropTable(
                name: "bounding_boxes",
                schema: "label");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "images_for_labelling",
                schema: "label");

            migrationBuilder.DropTable(
                name: "TrashType");

            migrationBuilder.DropTable(
                name: "TrajectoryPoint");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
