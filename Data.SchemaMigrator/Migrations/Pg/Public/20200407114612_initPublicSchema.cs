using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations.Pg.Public
{
    public partial class initPublicSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_buffercache", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis_topology", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cours_d_eau",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    importance = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    maree = table.Column<string>(nullable: true),
                    permanent = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "hydro_node_06",
                columns: table => new
                {
                    the_geom = table.Column<Geometry>(nullable: true),
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    code_pays = table.Column<string>(nullable: true),
                    categorie = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    prec_alti = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    src_alti = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    id_ce_amon = table.Column<string>(nullable: true),
                    id_ce_aval = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "model",
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
                name: "monitoring_blocked_queries",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: true),
                    blocked_by = table.Column<int[]>(nullable: true),
                    blocked_query = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "monitoring_running_queries",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: true),
                    application_name = table.Column<string>(nullable: true),
                    backend_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    query_start = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    wait_event_type = table.Column<string>(nullable: true),
                    wait_event = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    query = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "node",
                columns: table => new
                {
                    the_geom = table.Column<Geometry>(nullable: true),
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    code_pays = table.Column<string>(nullable: true),
                    categorie = table.Column<string>(nullable: true),
                    toponyme = table.Column<string>(nullable: true),
                    statut_top = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    prec_alti = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    src_alti = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    id_ce_amon = table.Column<string>(nullable: true),
                    id_ce_aval = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "pg_buffercache",
                columns: table => new
                {
                    bufferid = table.Column<int>(nullable: true),
                    relfilenode = table.Column<uint>(type: "oid", nullable: true),
                    reltablespace = table.Column<uint>(type: "oid", nullable: true),
                    reldatabase = table.Column<uint>(type: "oid", nullable: true),
                    relforknumber = table.Column<short>(nullable: true),
                    relblocknumber = table.Column<long>(nullable: true),
                    isdirty = table.Column<bool>(nullable: true),
                    usagecount = table.Column<short>(nullable: true),
                    pinning_backends = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "pg_stat_statements",
                columns: table => new
                {
                    userid = table.Column<uint>(type: "oid", nullable: true),
                    dbid = table.Column<uint>(type: "oid", nullable: true),
                    queryid = table.Column<long>(nullable: true),
                    query = table.Column<string>(nullable: true),
                    calls = table.Column<long>(nullable: true),
                    total_time = table.Column<double>(nullable: true),
                    min_time = table.Column<double>(nullable: true),
                    max_time = table.Column<double>(nullable: true),
                    mean_time = table.Column<double>(nullable: true),
                    stddev_time = table.Column<double>(nullable: true),
                    rows = table.Column<long>(nullable: true),
                    shared_blks_hit = table.Column<long>(nullable: true),
                    shared_blks_read = table.Column<long>(nullable: true),
                    shared_blks_dirtied = table.Column<long>(nullable: true),
                    shared_blks_written = table.Column<long>(nullable: true),
                    local_blks_hit = table.Column<long>(nullable: true),
                    local_blks_read = table.Column<long>(nullable: true),
                    local_blks_dirtied = table.Column<long>(nullable: true),
                    local_blks_written = table.Column<long>(nullable: true),
                    temp_blks_read = table.Column<long>(nullable: true),
                    temp_blks_written = table.Column<long>(nullable: true),
                    blk_read_time = table.Column<double>(nullable: true),
                    blk_write_time = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "river_06",
                columns: table => new
                {
                    id = table.Column<int>(nullable: true),
                    the_geom = table.Column<Geometry>(nullable: true),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    importance = table.Column<int>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    bras = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "river_06_ce",
                columns: table => new
                {
                    the_geom = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "surface_hydrographique",
                columns: table => new
                {
                    id = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    code_pays = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    pos_sol = table.Column<string>(nullable: true),
                    etat = table.Column<string>(nullable: true),
                    date_creat = table.Column<string>(nullable: true),
                    date_maj = table.Column<string>(nullable: true),
                    date_app = table.Column<string>(nullable: true),
                    date_conf = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    prec_plani = table.Column<string>(nullable: true),
                    prec_alti = table.Column<string>(nullable: true),
                    src_coord = table.Column<string>(nullable: true),
                    src_alti = table.Column<string>(nullable: true),
                    statut = table.Column<string>(nullable: true),
                    persistanc = table.Column<string>(nullable: true),
                    salinite = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    id_p_eau = table.Column<string>(nullable: true),
                    id_c_eau = table.Column<string>(nullable: true),
                    id_ent_tr = table.Column<string>(nullable: true),
                    nom_p_eau = table.Column<string>(nullable: true),
                    nom_c_eau = table.Column<string>(nullable: true),
                    nom_ent_tr = table.Column<string>(nullable: true),
                    geometry = table.Column<Geometry>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "trash_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_campaign",
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
                    table.PrimaryKey("PK_user_campaign", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "limits_land_sea",
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
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "river",
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
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_river", x => x.id);
                    table.ForeignKey(
                        name: "river_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "state",
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
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "campaign",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    locomotion = table.Column<string>(nullable: false),
                    isaidriven = table.Column<bool>(nullable: true),
                    remark = table.Column<string>(nullable: true),
                    id_ref_user_fk = table.Column<Guid>(nullable: true),
                    riverside = table.Column<string>(nullable: true),
                    startdate = table.Column<DateTime>(nullable: true),
                    enddate = table.Column<DateTime>(nullable: true),
                    duration = table.Column<TimeSpan>(nullable: true),
                    starting_point_the_geom = table.Column<Geometry>(nullable: true),
                    ending_point_the_geom = table.Column<Geometry>(nullable: true),
                    distance_start_end = table.Column<double>(nullable: true),
                    total_distance = table.Column<double>(nullable: true),
                    avg_speed = table.Column<double>(nullable: true),
                    file = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaign", x => x.id);
                    table.ForeignKey(
                        name: "campaign_id_ref_user_fk_fkey",
                        column: x => x.id_ref_user_fk,
                        principalTable: "user_campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "department",
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
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point",
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
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trajectory_point", x => x.id);
                    table.ForeignKey(
                        name: "trajectory_point_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "municipality",
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
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "image",
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
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "image_id_ref_trajectory_points_fk_fkey",
                        column: x => x.id_ref_trajectory_points_fk,
                        principalTable: "trajectory_point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trajectory_point_river",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_trajectory_point_fk = table.Column<Guid>(nullable: false),
                    id_ref_river_fk = table.Column<int>(nullable: false),
                    trajectory_point_the_geom = table.Column<Geometry>(nullable: false),
                    river_the_geom = table.Column<Geometry>(nullable: false),
                    closest_point_the_geom = table.Column<Geometry>(nullable: false),
                    distance_river_trajectory_point = table.Column<double>(nullable: false),
                    projection_trajectory_point_river_the_geom = table.Column<Geometry>(nullable: false),
                    importance = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trajectory_point_river", x => x.id);
                    table.ForeignKey(
                        name: "trajectory_point_river_id_ref_river_fk_fkey",
                        column: x => x.id_ref_river_fk,
                        principalTable: "river",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trajectory_point_river_id_ref_trajectory_point_fk_fkey",
                        column: x => x.id_ref_trajectory_point_fk,
                        principalTable: "trajectory_point",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trash",
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
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash", x => x.id);
                    table.ForeignKey(
                        name: "trash_id_ref_campaign_fk_fkey",
                        column: x => x.id_ref_campaign_fk,
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_image_fk_fkey",
                        column: x => x.id_ref_image_fk,
                        principalTable: "image",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_model_fk_fkey",
                        column: x => x.id_ref_model_fk,
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_id_ref_trash_type_fk_fkey",
                        column: x => x.id_ref_trash_type_fk,
                        principalTable: "trash_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trash_river",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ref_trash_fk = table.Column<Guid>(nullable: false),
                    id_ref_river_fk = table.Column<int>(nullable: false),
                    trash_the_geom = table.Column<Geometry>(nullable: false),
                    river_the_geom = table.Column<Geometry>(nullable: false),
                    closest_point_the_geom = table.Column<Geometry>(nullable: false),
                    distance_river_trash = table.Column<double>(nullable: false),
                    projection_trash_river_the_geom = table.Column<Geometry>(nullable: false),
                    importance = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trash_river", x => x.id);
                    table.ForeignKey(
                        name: "trash_river_id_ref_river_fk_fkey",
                        column: x => x.id_ref_river_fk,
                        principalTable: "river",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "trash_river_id_ref_trash_fk_fkey",
                        column: x => x.id_ref_trash_fk,
                        principalTable: "trash",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_campaign_id_ref_user_fk",
                table: "campaign",
                column: "id_ref_user_fk");

            migrationBuilder.CreateIndex(
                name: "country_code",
                table: "country",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "country_name_key",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "country_the_geom",
                table: "country",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "department_code",
                table: "department",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_department_id_ref_state_fk",
                table: "department",
                column: "id_ref_state_fk");

            migrationBuilder.CreateIndex(
                name: "department_name_key",
                table: "department",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "department_the_geom",
                table: "department",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_image_id_ref_campaign_fk",
                table: "image",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_image_id_ref_trajectory_points_fk",
                table: "image",
                column: "id_ref_trajectory_points_fk");

            migrationBuilder.CreateIndex(
                name: "IX_limits_land_sea_id_ref_country_fk",
                table: "limits_land_sea",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "limits_land_sea_the_geom",
                table: "limits_land_sea",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "municipality_code",
                table: "municipality",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_municipality_id_ref_department_fk",
                table: "municipality",
                column: "id_ref_department_fk");

            migrationBuilder.CreateIndex(
                name: "municipality_the_geom",
                table: "municipality",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "node_the_geom",
                table: "node",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_river_id_ref_country_fk",
                table: "river",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "river_importance",
                table: "river",
                column: "importance");

            migrationBuilder.CreateIndex(
                name: "river_name",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "river_the_geom",
                table: "river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "state_code",
                table: "state",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_state_id_ref_country_fk",
                table: "state",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "state_name_key",
                table: "state",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "state_the_geom",
                table: "state",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_id_ref_campaign_fk",
                table: "trajectory_point",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "trajectory_point_the_geom",
                table: "trajectory_point",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_river_id_ref_river_fk",
                table: "trajectory_point_river",
                column: "id_ref_river_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trajectory_point_river_id_ref_trajectory_point_fk",
                table: "trajectory_point_river",
                column: "id_ref_trajectory_point_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_campaign_fk",
                table: "trash",
                column: "id_ref_campaign_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_image_fk",
                table: "trash",
                column: "id_ref_image_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_model_fk",
                table: "trash",
                column: "id_ref_model_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_id_ref_trash_type_fk",
                table: "trash",
                column: "id_ref_trash_type_fk");

            migrationBuilder.CreateIndex(
                name: "trash_the_geom",
                table: "trash",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "trash_river_closest_point_the_geom",
                table: "trash_river",
                column: "closest_point_the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id_ref_river_fk",
                table: "trash_river",
                column: "id_ref_river_fk");

            migrationBuilder.CreateIndex(
                name: "IX_trash_river_id_ref_trash_fk",
                table: "trash_river",
                column: "id_ref_trash_fk");

            migrationBuilder.CreateIndex(
                name: "trash_type_type_key",
                table: "trash_type",
                column: "type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_campaign_firstname",
                table: "user_campaign",
                column: "firstname");

            migrationBuilder.CreateIndex(
                name: "user_campaign_lastname",
                table: "user_campaign",
                column: "lastname");

            migrationBuilder.CreateIndex(
                name: "user_campaign_firstname_lastname_key",
                table: "user_campaign",
                columns: new[] { "firstname", "lastname" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cours_d_eau");

            migrationBuilder.DropTable(
                name: "hydro_node_06");

            migrationBuilder.DropTable(
                name: "limits_land_sea");

            migrationBuilder.DropTable(
                name: "monitoring_blocked_queries");

            migrationBuilder.DropTable(
                name: "monitoring_running_queries");

            migrationBuilder.DropTable(
                name: "municipality");

            migrationBuilder.DropTable(
                name: "node");

            migrationBuilder.DropTable(
                name: "pg_buffercache");

            migrationBuilder.DropTable(
                name: "pg_stat_statements");

            migrationBuilder.DropTable(
                name: "river_06");

            migrationBuilder.DropTable(
                name: "river_06_ce");

            migrationBuilder.DropTable(
                name: "surface_hydrographique");

            migrationBuilder.DropTable(
                name: "trajectory_point_river");

            migrationBuilder.DropTable(
                name: "trash_river");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "river");

            migrationBuilder.DropTable(
                name: "trash");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "model");

            migrationBuilder.DropTable(
                name: "trash_type");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "trajectory_point");

            migrationBuilder.DropTable(
                name: "campaign");

            migrationBuilder.DropTable(
                name: "user_campaign");
        }
    }
}
