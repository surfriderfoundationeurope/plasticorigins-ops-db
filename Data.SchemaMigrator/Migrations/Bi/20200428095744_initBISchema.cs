using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations.Bi
{
    public partial class initBISchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bi");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_buffercache", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis_topology", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "campaign",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_campaign_fk = table.Column<string>(nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    start_point = table.Column<Geometry>(nullable: true),
                    end_point = table.Column<Geometry>(nullable: true),
                    total_distance = table.Column<double>(nullable: true),
                    avg_speed = table.Column<int>(nullable: true),
                    duration = table.Column<TimeSpan>(nullable: true),
                    start_point_distance_sea = table.Column<double>(nullable: true),
                    end_point_distance_sea = table.Column<double>(nullable: true),
                    trash_count = table.Column<int>(nullable: true),
                    distance_start_end = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "campaign_river",
                schema: "bi",
                columns: table => new
                {
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    distance = table.Column<double>(nullable: true),
                    river_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "logs",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    initiated_on = table.Column<DateTime>(type: "date", nullable: false),
                    finished_on = table.Column<DateTime>(type: "date", nullable: false),
                    elapsed_time = table.Column<double>(nullable: true),
                    status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "river",
                schema: "bi",
                columns: table => new
                {
                    name = table.Column<string>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    length = table.Column<double>(nullable: true),
                    trash_detected = table.Column<long>(nullable: true),
                    distance_monitored = table.Column<double>(nullable: true),
                    trace = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point_river",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_trajectory_point_fk = table.Column<Guid>(nullable: false),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    id_ref_river_fk = table.Column<int>(nullable: false),
                    trajectory_point_the_geom = table.Column<Geometry>(nullable: false),
                    river_the_geom = table.Column<Geometry>(nullable: false),
                    closest_point_the_geom = table.Column<Geometry>(nullable: false),
                    distance_river_trajectory_point = table.Column<double>(nullable: false),
                    projection_trajectory_point_river_the_geom = table.Column<Geometry>(nullable: false),
                    importance = table.Column<int>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trajectory_point_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trash",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    id_ref_campaign_fk = table.Column<string[]>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    id_ref_trash_type_fk = table.Column<int>(nullable: false),
                    precision = table.Column<double>(nullable: true),
                    id_ref_model_fk = table.Column<string[]>(nullable: true),
                    brand_type = table.Column<string>(nullable: true),
                    id_ref_image_fk = table.Column<string[]>(nullable: true),
                    time = table.Column<DateTime[]>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trash_river",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_trash_fk = table.Column<Guid>(nullable: false),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    id_ref_river_fk = table.Column<int>(nullable: false),
                    trash_the_geom = table.Column<Geometry>(nullable: false),
                    river_the_geom = table.Column<Geometry>(nullable: false),
                    closest_point_the_geom = table.Column<Geometry>(nullable: false),
                    distance_river_trash = table.Column<double>(nullable: false),
                    projection_trash_river_the_geom = table.Column<Geometry>(nullable: false),
                    importance = table.Column<int>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_river", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "campaign_end_point",
                schema: "bi",
                table: "campaign",
                column: "end_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "campaign_id_ref_campaign_fk",
                schema: "bi",
                table: "campaign",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "campaign_start_point",
                schema: "bi",
                table: "campaign",
                column: "start_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "bi_trash_river_closest_point_the_geom",
                schema: "bi",
                table: "trash_river",
                column: "closest_point_the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "campaign",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "campaign_river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "logs",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trajectory_point_river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trash",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trash_river",
                schema: "bi");
        }
    }
}
