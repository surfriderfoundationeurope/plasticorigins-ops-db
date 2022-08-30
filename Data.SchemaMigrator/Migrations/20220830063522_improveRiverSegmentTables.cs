using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations
{
    public partial class improveRiverSegmentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "trash_river_closest_point_the_geom",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "bi_temp_river_name",
                schema: "bi_temp",
                table: "river");

            migrationBuilder.DropIndex(
                name: "campaign_end_point",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropIndex(
                name: "campaign_start_point",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropIndex(
                name: "trash_river_closest_point_the_geom",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "river_name",
                schema: "bi",
                table: "river");

            migrationBuilder.DropColumn(
                name: "closest_point_the_geom",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "distance_river_trash",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "importance",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "river_name",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "river_the_geom",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "trash_the_geom",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trash");

            migrationBuilder.DropColumn(
                name: "closest_point_the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "importance",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "river_name",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "river_the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "trajectory_point_the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trajectory_point");

            migrationBuilder.DropColumn(
                name: "count_unique_trash",
                schema: "bi_temp",
                table: "river");

            migrationBuilder.DropColumn(
                name: "length",
                schema: "bi_temp",
                table: "river");

            migrationBuilder.DropColumn(
                name: "feature_collection",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "river_name",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "RiverTheGeom",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "the_geom_raw",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "distance_on_river",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "total_distance",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "trash_per_km_on_river",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "closest_point_the_geom",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "distance_river_trash",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "importance",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "river_name",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "river_the_geom",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "trash_the_geom",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "closest_point_the_geom",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "importance",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "river_name",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "river_the_geom",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "trajectory_point_the_geom",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "count_unique_trash",
                schema: "bi",
                table: "river");

            migrationBuilder.DropColumn(
                name: "length",
                schema: "bi",
                table: "river");

            migrationBuilder.DropColumn(
                name: "river_name",
                schema: "bi",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "RiverTheGeom",
                schema: "bi",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "the_geom_raw",
                schema: "bi",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "distance_on_river",
                schema: "bi",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "total_distance",
                schema: "bi",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "trash_per_km_on_river",
                schema: "bi",
                table: "campaign");

            migrationBuilder.AddColumn<int>(
                name: "id_ref_segment_fk",
                schema: "bi_temp",
                table: "trash_river",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom",
                schema: "bi_temp",
                table: "trash_river",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_ref_segment_fk",
                schema: "bi_temp",
                table: "trajectory_point_river",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "time",
                schema: "bi_temp",
                table: "trajectory_point_river",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                schema: "bi_temp",
                table: "river",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "importance",
                schema: "bi_temp",
                table: "river",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nb_campaign",
                schema: "bi_temp",
                table: "river",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_ref_river_fk",
                schema: "bi_temp",
                table: "campaign_river",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "trash_count",
                schema: "bi_temp",
                table: "campaign_river",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "trash_per_km",
                schema: "bi_temp",
                table: "campaign_river",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "distance",
                schema: "bi_temp",
                table: "campaign",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom",
                schema: "bi_temp",
                table: "campaign",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feature_collection",
                schema: "bi",
                table: "trash_river",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_ref_segment_fk",
                schema: "bi",
                table: "trash_river",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom",
                schema: "bi",
                table: "trash_river",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_ref_segment_fk",
                schema: "bi",
                table: "trajectory_point_river",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom",
                schema: "bi",
                table: "trajectory_point_river",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "time",
                schema: "bi",
                table: "trajectory_point_river",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                schema: "bi",
                table: "river",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feature_collection",
                schema: "bi",
                table: "river",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "importance",
                schema: "bi",
                table: "river",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nb_campaign",
                schema: "bi",
                table: "river",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_ref_river_fk",
                schema: "bi",
                table: "campaign_river",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "trash_count",
                schema: "bi",
                table: "campaign_river",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "trash_per_km",
                schema: "bi",
                table: "campaign_river",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "distance",
                schema: "bi",
                table: "campaign",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom",
                schema: "bi",
                table: "campaign",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "segment",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    importance = table.Column<int>(nullable: true),
                    count_trash = table.Column<double>(nullable: true),
                    distance_monitored = table.Column<double>(nullable: true),
                    the_geom_monitored = table.Column<Geometry>(nullable: true),
                    trash_per_km = table.Column<decimal>(type: "numeric", nullable: true),
                    nb_campaign = table.Column<int>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    feature_collection = table.Column<string>(type: "jsonb", nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "segment",
                schema: "bi_temp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    importance = table.Column<int>(nullable: true),
                    count_trash = table.Column<double>(nullable: true),
                    distance_monitored = table.Column<double>(nullable: true),
                    the_geom_monitored = table.Column<Geometry>(nullable: true),
                    trash_per_km = table.Column<decimal>(type: "numeric", nullable: true),
                    nb_campaign = table.Column<int>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segment", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id1",
                schema: "bi_temp",
                table: "trash_river",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trash_river",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id_ref_river_fk",
                schema: "bi_temp",
                table: "trash_river",
                column: "id_ref_river_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id_ref_segment_fk",
                schema: "bi_temp",
                table: "trash_river",
                column: "id_ref_segment_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id1",
                schema: "bi_temp",
                table: "trash",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trash",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_river_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trajectory_point_river",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_river_id_ref_river_fk",
                schema: "bi_temp",
                table: "trajectory_point_river",
                column: "id_ref_river_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_id",
                schema: "bi_temp",
                table: "trajectory_point",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trajectory_point",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "bi_temp_river_id",
                schema: "bi_temp",
                table: "river",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_campaign_river_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "campaign_river",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id",
                schema: "bi",
                table: "trash_river",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id_ref_campaign_fk",
                schema: "bi",
                table: "trash_river",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id_ref_trash_fk",
                schema: "bi",
                table: "trash_river",
                column: "id_ref_trash_fk");

            migrationBuilder.CreateIndex(
                name: "trash_river_the_geom",
                schema: "bi",
                table: "trash_river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id",
                schema: "bi",
                table: "trash",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_campaign_fk",
                schema: "bi",
                table: "trash",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_river_id_ref_campaign_fk",
                schema: "bi",
                table: "trajectory_point_river",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_id_ref_campaign_fk",
                schema: "bi",
                table: "trajectory_point",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "river_id",
                schema: "bi",
                table: "river",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "river_bi_importance",
                schema: "bi",
                table: "river",
                column: "importance");

            migrationBuilder.CreateIndex(
                name: "IX_campaign_river_id_ref_campaign_fk",
                schema: "bi",
                table: "campaign_river",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "campaign_river_the_geom",
                schema: "bi",
                table: "campaign_river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "campaign_id",
                schema: "bi",
                table: "campaign",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "bi_segment_id",
                schema: "bi",
                table: "segment",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "bi_segment_importance",
                schema: "bi",
                table: "segment",
                column: "importance");

            migrationBuilder.CreateIndex(
                name: "segment_the_geom",
                schema: "bi",
                table: "segment",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "bi_temp_segment_id",
                schema: "bi_temp",
                table: "segment",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "segment",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "segment",
                schema: "bi_temp");

            migrationBuilder.DropIndex(
                name: "IX_trash_river_id1",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_river_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_river_id_ref_river_fk",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_river_id_ref_segment_fk",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_id1",
                schema: "bi_temp",
                table: "trash");

            migrationBuilder.DropIndex(
                name: "IX_trash_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trash");

            migrationBuilder.DropIndex(
                name: "IX_trajectory_point_river_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropIndex(
                name: "IX_trajectory_point_river_id_ref_river_fk",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropIndex(
                name: "IX_trajectory_point_id",
                schema: "bi_temp",
                table: "trajectory_point");

            migrationBuilder.DropIndex(
                name: "IX_trajectory_point_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "trajectory_point");

            migrationBuilder.DropIndex(
                name: "bi_temp_river_id",
                schema: "bi_temp",
                table: "river");

            migrationBuilder.DropIndex(
                name: "IX_campaign_river_id_ref_campaign_fk1",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_river_id",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_river_id_ref_campaign_fk",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_river_id_ref_trash_fk",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "trash_river_the_geom",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropIndex(
                name: "IX_trash_id",
                schema: "bi",
                table: "trash");

            migrationBuilder.DropIndex(
                name: "IX_trash_id_ref_campaign_fk",
                schema: "bi",
                table: "trash");

            migrationBuilder.DropIndex(
                name: "IX_trajectory_point_river_id_ref_campaign_fk",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropIndex(
                name: "IX_trajectory_point_id_ref_campaign_fk",
                schema: "bi",
                table: "trajectory_point");

            migrationBuilder.DropIndex(
                name: "river_id",
                schema: "bi",
                table: "river");

            migrationBuilder.DropIndex(
                name: "river_bi_importance",
                schema: "bi",
                table: "river");

            migrationBuilder.DropIndex(
                name: "IX_campaign_river_id_ref_campaign_fk",
                schema: "bi",
                table: "campaign_river");

            migrationBuilder.DropIndex(
                name: "campaign_river_the_geom",
                schema: "bi",
                table: "campaign_river");

            migrationBuilder.DropIndex(
                name: "campaign_id",
                schema: "bi",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "id_ref_segment_fk",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "the_geom",
                schema: "bi_temp",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "id_ref_segment_fk",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "time",
                schema: "bi_temp",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "createdon",
                schema: "bi_temp",
                table: "river");

            migrationBuilder.DropColumn(
                name: "importance",
                schema: "bi_temp",
                table: "river");

            migrationBuilder.DropColumn(
                name: "nb_campaign",
                schema: "bi_temp",
                table: "river");

            migrationBuilder.DropColumn(
                name: "trash_count",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "trash_per_km",
                schema: "bi_temp",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "distance",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "the_geom",
                schema: "bi_temp",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "feature_collection",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "id_ref_segment_fk",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "the_geom",
                schema: "bi",
                table: "trash_river");

            migrationBuilder.DropColumn(
                name: "id_ref_segment_fk",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "the_geom",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "time",
                schema: "bi",
                table: "trajectory_point_river");

            migrationBuilder.DropColumn(
                name: "createdon",
                schema: "bi",
                table: "river");

            migrationBuilder.DropColumn(
                name: "feature_collection",
                schema: "bi",
                table: "river");

            migrationBuilder.DropColumn(
                name: "importance",
                schema: "bi",
                table: "river");

            migrationBuilder.DropColumn(
                name: "nb_campaign",
                schema: "bi",
                table: "river");

            migrationBuilder.DropColumn(
                name: "trash_count",
                schema: "bi",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "trash_per_km",
                schema: "bi",
                table: "campaign_river");

            migrationBuilder.DropColumn(
                name: "distance",
                schema: "bi",
                table: "campaign");

            migrationBuilder.DropColumn(
                name: "the_geom",
                schema: "bi",
                table: "campaign");

            migrationBuilder.AddColumn<Geometry>(
                name: "closest_point_the_geom",
                schema: "bi_temp",
                table: "trash_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "distance_river_trash",
                schema: "bi_temp",
                table: "trash_river",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "importance",
                schema: "bi_temp",
                table: "trash_river",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trash_river",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "river_name",
                schema: "bi_temp",
                table: "trash_river",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "river_the_geom",
                schema: "bi_temp",
                table: "trash_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<Geometry>(
                name: "trash_the_geom",
                schema: "bi_temp",
                table: "trash_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trash",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "closest_point_the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "importance",
                schema: "bi_temp",
                table: "trajectory_point_river",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trajectory_point_river",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "river_name",
                schema: "bi_temp",
                table: "trajectory_point_river",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "river_the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<Geometry>(
                name: "trajectory_point_the_geom",
                schema: "bi_temp",
                table: "trajectory_point_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "trajectory_point",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "count_unique_trash",
                schema: "bi_temp",
                table: "river",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "length",
                schema: "bi_temp",
                table: "river",
                type: "double precision",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_ref_river_fk",
                schema: "bi_temp",
                table: "campaign_river",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "feature_collection",
                schema: "bi_temp",
                table: "campaign_river",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "campaign_river",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "river_name",
                schema: "bi_temp",
                table: "campaign_river",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "RiverTheGeom",
                schema: "bi_temp",
                table: "campaign_river",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom_raw",
                schema: "bi_temp",
                table: "campaign_river",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "distance_on_river",
                schema: "bi_temp",
                table: "campaign",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "pipeline_id",
                schema: "bi_temp",
                table: "campaign",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_distance",
                schema: "bi_temp",
                table: "campaign",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "trash_per_km_on_river",
                schema: "bi_temp",
                table: "campaign",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "closest_point_the_geom",
                schema: "bi",
                table: "trash_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "distance_river_trash",
                schema: "bi",
                table: "trash_river",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "importance",
                schema: "bi",
                table: "trash_river",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "river_name",
                schema: "bi",
                table: "trash_river",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "river_the_geom",
                schema: "bi",
                table: "trash_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<Geometry>(
                name: "trash_the_geom",
                schema: "bi",
                table: "trash_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<Geometry>(
                name: "closest_point_the_geom",
                schema: "bi",
                table: "trajectory_point_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "importance",
                schema: "bi",
                table: "trajectory_point_river",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "river_name",
                schema: "bi",
                table: "trajectory_point_river",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "river_the_geom",
                schema: "bi",
                table: "trajectory_point_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<Geometry>(
                name: "trajectory_point_the_geom",
                schema: "bi",
                table: "trajectory_point_river",
                type: "geometry",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "count_unique_trash",
                schema: "bi",
                table: "river",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "length",
                schema: "bi",
                table: "river",
                type: "double precision",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_ref_river_fk",
                schema: "bi",
                table: "campaign_river",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "river_name",
                schema: "bi",
                table: "campaign_river",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "RiverTheGeom",
                schema: "bi",
                table: "campaign_river",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<Geometry>(
                name: "the_geom_raw",
                schema: "bi",
                table: "campaign_river",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "distance_on_river",
                schema: "bi",
                table: "campaign",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "total_distance",
                schema: "bi",
                table: "campaign",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "trash_per_km_on_river",
                schema: "bi",
                table: "campaign",
                type: "numeric",
                nullable: true);
            
            migrationBuilder.CreateIndex(
                name: "trash_river_closest_point_the_geom",
                schema: "bi_temp",
                table: "trash_river",
                column: "closest_point_the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "bi_temp_river_name",
                schema: "bi_temp",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "campaign_end_point",
                schema: "bi_temp",
                table: "campaign",
                column: "end_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "campaign_start_point",
                schema: "bi_temp",
                table: "campaign",
                column: "start_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "trash_river_closest_point_the_geom",
                schema: "bi",
                table: "trash_river",
                column: "closest_point_the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "river_name",
                schema: "bi",
                table: "river",
                column: "name");
        }
    }
}
