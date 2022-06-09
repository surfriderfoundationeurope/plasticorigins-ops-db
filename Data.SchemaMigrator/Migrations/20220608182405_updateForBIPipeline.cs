using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations
{
    public partial class updateForBIPipeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "referential");

            migrationBuilder.EnsureSchema(
                name: "bi");

            migrationBuilder.EnsureSchema(
                name: "bi_temp");

            migrationBuilder.AddColumn<string>(
                name: "container",
                schema: "logs",
                table: "etl",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "has_been_computed",
                schema: "campaign",
                table: "campaign",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "campaign",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    locomotion = table.Column<string>(nullable: true),
                    isaidriven = table.Column<bool>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    id_ref_user_fk = table.Column<Guid>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: true),
                    end_date = table.Column<DateTime>(nullable: true),
                    start_point = table.Column<Geometry>(nullable: true),
                    end_point = table.Column<Geometry>(nullable: true),
                    total_distance = table.Column<double>(nullable: true),
                    distance_on_river = table.Column<double>(nullable: true),
                    avg_speed = table.Column<int>(nullable: true),
                    duration = table.Column<TimeSpan>(nullable: true),
                    trash_count = table.Column<int>(nullable: true),
                    trash_per_km = table.Column<decimal>(type: "numeric", nullable: true),
                    trash_per_km_on_river = table.Column<decimal>(type: "numeric", nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    distance = table.Column<decimal>(type: "numeric", nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    the_geom_raw = table.Column<Geometry>(nullable: true),
                    RiverTheGeom = table.Column<Geometry>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    feature_collection = table.Column<string>(type: "jsonb", nullable: true),
                    id_ref_river_fk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "river",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    length = table.Column<double>(nullable: true),
                    count_unique_trash = table.Column<double>(nullable: true),
                    count_trash = table.Column<double>(nullable: true),
                    distance_monitored = table.Column<double>(nullable: true),
                    the_geom_monitored = table.Column<Geometry>(nullable: true),
                    trash_per_km = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
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
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    the_geom = table.Column<Geometry>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    id_ref_trash_type_fk = table.Column<int>(nullable: false),
                    precision = table.Column<double>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    id_ref_image_fk = table.Column<Guid>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    municipality_name = table.Column<string>(nullable: true),
                    municipality_code = table.Column<string>(nullable: true),
                    department_name = table.Column<string>(nullable: true),
                    department_code = table.Column<string>(nullable: true),
                    state_code = table.Column<string>(nullable: true),
                    state_name = table.Column<string>(nullable: true),
                    country_code = table.Column<string>(nullable: true),
                    country_name = table.Column<string>(nullable: true),
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
                    importance = table.Column<int>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "campaign",
                schema: "bi_temp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    locomotion = table.Column<string>(nullable: true),
                    isaidriven = table.Column<bool>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    id_ref_user_fk = table.Column<Guid>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: true),
                    end_date = table.Column<DateTime>(nullable: true),
                    start_point = table.Column<Geometry>(nullable: true),
                    end_point = table.Column<Geometry>(nullable: true),
                    total_distance = table.Column<double>(nullable: true),
                    distance_on_river = table.Column<double>(nullable: true),
                    avg_speed = table.Column<int>(nullable: true),
                    duration = table.Column<TimeSpan>(nullable: true),
                    start_point_distance_sea = table.Column<double>(nullable: true),
                    end_point_distance_sea = table.Column<double>(nullable: true),
                    trash_count = table.Column<int>(nullable: true),
                    trash_per_km = table.Column<decimal>(type: "numeric", nullable: true),
                    trash_per_km_on_river = table.Column<decimal>(type: "numeric", nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    pipeline_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "campaign_river",
                schema: "bi_temp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    distance = table.Column<decimal>(type: "numeric", nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    the_geom_raw = table.Column<Geometry>(nullable: true),
                    RiverTheGeom = table.Column<Geometry>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    feature_collection = table.Column<string>(type: "jsonb", nullable: true),
                    id_ref_river_fk = table.Column<int>(nullable: true),
                    pipeline_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pipelines",
                schema: "bi_temp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    campaign_id = table.Column<Guid>(nullable: false),
                    campaign_has_been_computed = table.Column<bool>(nullable: true),
                    river_has_been_computed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pipelines", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "river",
                schema: "bi_temp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    length = table.Column<double>(nullable: true),
                    count_unique_trash = table.Column<double>(nullable: true),
                    count_trash = table.Column<double>(nullable: true),
                    distance_monitored = table.Column<double>(nullable: true),
                    the_geom_monitored = table.Column<Geometry>(nullable: true),
                    trash_per_km = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point",
                schema: "bi_temp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    distance = table.Column<double>(nullable: true),
                    time_diff = table.Column<TimeSpan>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    speed = table.Column<double>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    pipeline_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point_river",
                schema: "bi_temp",
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
                    importance = table.Column<int>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    pipeline_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trajectory_point_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trash",
                schema: "bi_temp",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    id_ref_campaign_fk = table.Column<Guid>(nullable: false),
                    the_geom = table.Column<Geometry>(nullable: true),
                    elevation = table.Column<double>(nullable: true),
                    id_ref_trash_type_fk = table.Column<int>(nullable: false),
                    precision = table.Column<double>(nullable: true),
                    id_ref_model_fk = table.Column<Guid>(nullable: true),
                    id_ref_media_fk = table.Column<Guid>(nullable: true),
                    time = table.Column<DateTime>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lon = table.Column<double>(nullable: true),
                    municipality_name = table.Column<string>(nullable: true),
                    municipality_code = table.Column<string>(nullable: true),
                    department_name = table.Column<string>(nullable: true),
                    department_code = table.Column<string>(nullable: true),
                    state_code = table.Column<string>(nullable: true),
                    state_name = table.Column<string>(nullable: true),
                    country_code = table.Column<string>(nullable: true),
                    country_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    pipeline_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trash_river",
                schema: "bi_temp",
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
                    importance = table.Column<int>(nullable: true),
                    river_name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    pipeline_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_river", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "basin",
                schema: "referential",
                columns: table => new
                {
                    basin_id = table.Column<string>(nullable: false),
                    fec_count = table.Column<int>(nullable: false),
                    basin_name = table.Column<string>(nullable: true),
                    country_code = table.Column<string>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    feature_collection = table.Column<string>(type: "jsonb", nullable: true),
                    area_square_km = table.Column<double>(nullable: false),
                    the_geom_bb = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basin", x => x.basin_id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    feature_collection = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "limits_land_sea",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_limits_land_sea", x => x.id);
                    table.ForeignKey(
                        name: "limits_land_sea_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "river",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    importance = table.Column<int>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    bras = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true),
                    feature_collection = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_river", x => x.id);
                    table.ForeignKey(
                        name: "river_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "state",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                    table.ForeignKey(
                        name: "state_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "department",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_state_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "department_id_ref_state_fk_fkey",
                        column: x => x.id_ref_state_fk,
                        principalSchema: "referential",
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "municipality",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_department_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipality", x => x.id);
                    table.ForeignKey(
                        name: "municipality_id_ref_department_fk_fkey",
                        column: x => x.id_ref_department_fk,
                        principalSchema: "referential",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "campaign_end_point",
                schema: "bi",
                table: "campaign",
                column: "end_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "campaign_start_point",
                schema: "bi",
                table: "campaign",
                column: "start_point")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "river_name",
                schema: "bi",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "river_the_geom",
                schema: "bi",
                table: "river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "bi_trash_the_geom",
                schema: "bi",
                table: "trash",
                column: "the_geom");

            migrationBuilder.CreateIndex(
                name: "trash_river_closest_point_the_geom",
                schema: "bi",
                table: "trash_river",
                column: "closest_point_the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

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
                name: "bi_temp_river_name",
                schema: "bi_temp",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "bi_trash_the_geom",
                schema: "bi_temp",
                table: "trash",
                column: "the_geom");

            migrationBuilder.CreateIndex(
                name: "trash_river_closest_point_the_geom",
                schema: "bi_temp",
                table: "trash_river",
                column: "closest_point_the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_basin_area_square_km",
                schema: "referential",
                table: "basin",
                column: "area_square_km");

            migrationBuilder.CreateIndex(
                name: "IX_basin_the_geom_bb",
                schema: "referential",
                table: "basin",
                column: "the_geom_bb")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "country_code",
                schema: "referential",
                table: "country",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "country_name_key",
                schema: "referential",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "country_the_geom",
                schema: "referential",
                table: "country",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "referential_department_code",
                schema: "referential",
                table: "department",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_department_id_ref_state_fk",
                schema: "referential",
                table: "department",
                column: "id_ref_state_fk");

            migrationBuilder.CreateIndex(
                name: "department_name_key",
                schema: "referential",
                table: "department",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "referential_department_the_geom",
                schema: "referential",
                table: "department",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_limits_land_sea_id_ref_country_fk",
                schema: "referential",
                table: "limits_land_sea",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "limits_land_sea_the_geom",
                schema: "referential",
                table: "limits_land_sea",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "municipality_code",
                schema: "referential",
                table: "municipality",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_municipality_id_ref_department_fk",
                schema: "referential",
                table: "municipality",
                column: "id_ref_department_fk");

            migrationBuilder.CreateIndex(
                name: "municipality_the_geom",
                schema: "referential",
                table: "municipality",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_river_id_ref_country_fk",
                schema: "referential",
                table: "river",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "river_importance",
                schema: "referential",
                table: "river",
                column: "importance");

            migrationBuilder.CreateIndex(
                name: "river_name",
                schema: "referential",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "river_the_geom",
                schema: "referential",
                table: "river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "state_code",
                schema: "referential",
                table: "state",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_state_id_ref_country_fk",
                schema: "referential",
                table: "state",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "state_name_key",
                schema: "referential",
                table: "state",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "state_the_geom",
                schema: "referential",
                table: "state",
                column: "the_geom")
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
                name: "river",
                schema: "bi");

            migrationBuilder.DropTable(
                name: "trajectory_point",
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

            migrationBuilder.DropTable(
                name: "campaign",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "campaign_river",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "pipelines",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "river",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "trajectory_point",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "trajectory_point_river",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "trash",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "trash_river",
                schema: "bi_temp");

            migrationBuilder.DropTable(
                name: "basin",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "limits_land_sea",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "municipality",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "river",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "department",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "state",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "country",
                schema: "referential");

            migrationBuilder.DropColumn(
                name: "container",
                schema: "logs",
                table: "etl");

            migrationBuilder.DropColumn(
                name: "has_been_computed",
                schema: "campaign",
                table: "campaign");
        }
    }
}
