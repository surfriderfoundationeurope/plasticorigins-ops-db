using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations.Campaign
{
    public partial class initCampaignSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "campaign");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_buffercache", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis_topology", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "model",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    version = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trash_type",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true),
                    brand = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: false),
                    emailconfirmed = table.Column<bool>(nullable: false),
                    passwordhash = table.Column<string>(nullable: true),
                    yearofbirth = table.Column<DateTime>(type: "date", nullable: true),
                    experience = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "campaign",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    locomotion = table.Column<string>(nullable: false),
                    isaidriven = table.Column<bool>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    id_ref_user_fk = table.Column<Guid>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    container_url = table.Column<string>(nullable: true),
                    blob_name = table.Column<string>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.id);
                    table.ForeignKey(
                        name: "campaign_id_ref_model_fk_fkey",
                        column: x => x.id_ref_model_fk,
                        principalSchema: "campaign",
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "campaign_id_ref_user_fk_fkey",
                        column: x => x.id_ref_user_fk,
                        principalSchema: "campaign",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    the_geom = table.Column<Geometry>(nullable: true),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    elevation = table.Column<double>(nullable: true),
                    distance = table.Column<double>(nullable: true),
                    time_diff = table.Column<TimeSpan>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    speed = table.Column<double>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trajectory_point", x => x.id);
                    table.ForeignKey(
                        name: "trajectory_point_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "image",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    filename = table.Column<string>(nullable: false),
                    blobname = table.Column<string>(nullable: false),
                    containerurl = table.Column<string>(nullable: false),
                    createdby = table.Column<string>(nullable: false),
                    isdeleted = table.Column<BitArray>(type: "bit(1)", nullable: false),
                    version = table.Column<int>(nullable: false),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    id_ref_trajectory_points_fk = table.Column<Guid>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image", x => x.id);
                    table.ForeignKey(
                        name: "image_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "image_id_ref_trajectory_points_fk_fkey",
                        column: x => x.id_ref_trajectory_points_fk,
                        principalSchema: "campaign",
                        principalTable: "trajectory_point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trash",
                schema: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    the_geom = table.Column<Geometry>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    id_ref_trash_type_fk = table.Column<int>(nullable: false),
                    precision = table.Column<double>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    brand_type = table.Column<string>(nullable: true),
                    id_ref_image_fk = table.Column<Guid>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash", x => x.id);
                    table.ForeignKey(
                        name: "trash_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_image_fk_fkey",
                        column: x => x.id_ref_image_fk,
                        principalSchema: "campaign",
                        principalTable: "image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_model_fk_fkey",
                        column: x => x.id_ref_model_fk,
                        principalSchema: "campaign",
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_trash_type_fk_fkey",
                        column: x => x.id_ref_trash_type_fk,
                        principalSchema: "campaign",
                        principalTable: "trash_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "campaign_id",
                schema: "campaign",
                table: "campaign",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_campaign_id_ref_model_fk",
                schema: "campaign",
                table: "campaign",
                column: "id_ref_model_fk");

            migrationBuilder.CreateIndex(
                name: "IX_campaign_id_ref_user_fk",
                schema: "campaign",
                table: "campaign",
                column: "id_ref_user_fk");

            migrationBuilder.CreateIndex(
                name: "IX_image_id_ref_campaign_fk",
                schema: "campaign",
                table: "image",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_image_id_ref_trajectory_points_fk",
                schema: "campaign",
                table: "image",
                column: "id_ref_trajectory_points_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_id_ref_campaign_fk",
                schema: "campaign",
                table: "trajectory_point",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "trajectory_point_the_geom",
                schema: "campaign",
                table: "trajectory_point",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_campaign_fk",
                schema: "campaign",
                table: "trash",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_image_fk",
                schema: "campaign",
                table: "trash",
                column: "id_ref_image_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_model_fk",
                schema: "campaign",
                table: "trash",
                column: "id_ref_model_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_trash_type_fk",
                schema: "campaign",
                table: "trash",
                column: "id_ref_trash_type_fk");

            migrationBuilder.CreateIndex(
                name: "trash_the_geom",
                schema: "campaign",
                table: "trash",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "trash_type_type_key",
                schema: "campaign",
                table: "trash_type",
                column: "type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_firstname",
                schema: "campaign",
                table: "user",
                column: "firstname");

            migrationBuilder.CreateIndex(
                name: "user_lastname",
                schema: "campaign",
                table: "user",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "user_firstname_lastname_key",
                schema: "campaign",
                table: "user",
                columns: new[] { "firstname", "lastname" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trash",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "image",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "trash_type",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "trajectory_point",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "campaign",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "model",
                schema: "campaign");

            migrationBuilder.DropTable(
                name: "user",
                schema: "campaign");
        }
    }
}
